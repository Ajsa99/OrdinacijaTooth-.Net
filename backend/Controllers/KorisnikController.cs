using backend.Dtos;
using backend.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Model;
using AutoMapper;
using MediatR;
using backend.Queries.PacijentQueries;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly ILogger<KorisnikController> Ilogger;
        private readonly IMediator mediator;

        public KorisnikController(IUnitOfWork uow, IConfiguration configuration, IMapper mapper, ILogger<KorisnikController> Ilogger, IMediator mediator)
        {
            this.uow = uow;
            this.configuration = configuration;
            this.mapper = mapper;
            this.Ilogger = Ilogger;
            this.mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetKorisnici()
        {

            var korisnik = await uow.KorisnikRepository.GetKorisniciAsync();

            var korisnikGetDto = mapper.Map<IEnumerable<GetKorisnikDto>>(korisnik);

            //var korisnikGetDto = from u in korisnik
            //                 select new GetKorisnikDto()
            //                 {
            //                     Id = u.Id,
            //                     Ime = u.Ime,
            //                     Prezime = u.Prezime,
            //                     Pol = u.Pol,
            //                     DatumRodjenja = u.DatumRodjenja,
            //                     Telefon = u.Telefon,
            //                     Drzava = u.Drzava,
            //                     Grad = u.Grad,
            //                     Adresa = u.Adresa,
            //                     Email = u.Email,
            //                     Tip = u.Tip,
            //                     Odobrenje = u.Odobrenje
            //                 };

            return Ok(korisnikGetDto);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetKorisnik(int id)
        {

            var korisnik = await uow.KorisnikRepository.GetKorisnikAsync(id);

            if (korisnik == null)
            {
                return NotFound(); // Ako zahtev sa datim ID-om ne postoji, vraćamo NotFound status
            }

            var GetKorisnikDto = mapper.Map<GetKorisnikDto>(korisnik);

            return Ok(GetKorisnikDto);
        }

        private string? CreateJWT(Korisnik korisnik)
        {
       
                var secretKey = configuration.GetSection("AppSettings:Key").Value;
                var key = new SymmetricSecurityKey(Encoding.UTF8
                         .GetBytes(secretKey!));

                var claims = new Claim[]
                {
                new Claim(ClaimTypes.Email, korisnik.Email),
                new Claim(ClaimTypes.NameIdentifier, korisnik.Id.ToString()),
                new Claim("Tip", korisnik.Tip),
                new Claim("Ime", korisnik.Ime),
                new Claim("Prezime", korisnik.Prezime),
                };

                var signingCredentials = new SigningCredentials(
                   key, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginReq1Dto loginReq)
        {

            Console.WriteLine(loginReq.Email);

            var korisnik = await uow.KorisnikRepository.Authenticate(loginReq.Email!, loginReq.Password!);

            if (korisnik == null)
            {
                return Unauthorized();
            }

            if (korisnik.Odobrenje == 0)
            {
                return BadRequest("Registracija korisnika je na čekanju.");
            }

            var login = new LoginResDto();
            login.Email = korisnik.Email;
            login.Token = CreateJWT(korisnik);

            return Ok(login);
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
            if (await uow.KorisnikRepository.KorisnikAlreadyExists(loginReq.Email!))
            {
                return BadRequest("Korisnik sa emailom " + loginReq.Email + " već postoji.");
            }

            int odobrenje = 0;

            if (loginReq.Tip! == "Administrator")
            {
                odobrenje = 1;
            }


            uow.KorisnikRepository.Register(loginReq.Ime!, loginReq.Prezime!, loginReq.Pol!, (DateTime)loginReq.DatumRodjenja!, (int)loginReq.Telefon, loginReq.Drzava!,
                loginReq.Grad!, loginReq.Adresa!, loginReq.Email!, loginReq.Password!, loginReq.Tip!, odobrenje);
            await uow.SaveAsync();
            return Ok(loginReq);
        }

        [HttpPut("odobrenjeRegistracije/{id}")]
        public async Task<IActionResult> ApproveRegistration(int id)
        {
            var korisnik = await uow.KorisnikRepository.GetKorisnikAsync(id);

            if (korisnik == null)
            {
                return NotFound("Korisnik sa datim ID-om nije pronađen.");
            }

            korisnik.Odobrenje = 1; // Postavljamo vrednost Odobrenje na 1

            await uow.SaveAsync(); // Čuvamo promene u bazi podataka
            return Ok("Registracija korisnika je odobrena.");
        }

        [HttpDelete("DeleteKorisnik/{id}")]
        public async Task<IActionResult> DeleteKorisnik(int id)
        {
            uow.KorisnikRepository.DeleteKorisnik(id);

            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet("FilterKorisnik/{imePrezime}")]
        public async Task<IActionResult> FilterKorisnik(string imePrezime)
        {
            var korisnici = await uow.KorisnikRepository.GetKorisniciAsync();

            var korisnikGetDto = mapper.Map<IEnumerable<GetKorisnikDto>>(korisnici);

            var filterKorisnici = korisnikGetDto.Where(k =>
                k.Ime.IndexOf(imePrezime, StringComparison.OrdinalIgnoreCase) >= 0 ||
                k.Prezime.IndexOf(imePrezime, StringComparison.OrdinalIgnoreCase) >= 0);

            return Ok(filterKorisnici);
        }

        [HttpGet("sortKorisniciIme")]
        public IActionResult SortKorisniciIme()
        {
            var korisnici = uow.KorisnikRepository.GetKorisniciAsync().Result;

            var KorisnikDto = mapper.Map<IEnumerable<GetKorisnikDto>>(korisnici);

            // Sortiranje pacijenata po imenu (abecedno)
            var sortiraniKorisnici = KorisnikDto.OrderBy(p => p.Ime).ToList();

            return Ok(sortiraniKorisnici);


        }

        [HttpGet("sortKorisniciPrezime")]
        public IActionResult SortKorisniciPrezime()
        {
            var korisnici = uow.KorisnikRepository.GetKorisniciAsync().Result;

            var KorisnikDto = mapper.Map<IEnumerable<GetKorisnikDto>>(korisnici);

            // Sortiranje pacijenata po prezimenu (abecedno)
            var sortiraniKorisnici = KorisnikDto.OrderBy(p => p.Prezime).ToList();

            return Ok(sortiraniKorisnici);
        }

    }
}
