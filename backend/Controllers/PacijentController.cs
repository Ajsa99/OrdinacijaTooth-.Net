using backend.Dtos;
using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacijentController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public PacijentController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        [HttpGet("getPacijenti")]
        public async Task<IActionResult> GetPacijenti()
        {
            var pacijent = await uow.PacijentRepository.GetPacijentiAsync();

            var GetPacijentDto = from p in pacijent
                                 select new GetPacijentDto()
                                 {
                                     Id = p.Id,
                                     Ime = p.Ime,
                                     Prezime = p.Prezime,
                                     Pol = p.Pol,
                                     DatumRodjenja = p.DatumRodjenja,
                                     Telefon = p.Telefon,
                                     Drzava = p.Drzava,
                                     Grad = p.Grad,
                                     Adresa = p.Adresa,
                                     Email = p.Email,
                                     KorisnikId = p.KorisnikId,
                                 };

            return Ok(GetPacijentDto);
        }

  

        [HttpGet("getPacijent/{id}")]
        public async Task<IActionResult> GetPacijent(int id)
        {
            var pacijent = await uow.PacijentRepository.GetPacijentAsync(id);

            if (pacijent == null)
            {
                return NotFound(); // Ako zahtev sa datim ID-om ne postoji, vraćamo NotFound status
            }

            var GetPacijentDto = new GetPacijentDto()
            {
                Id = pacijent.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                Pol = pacijent.Pol,
                DatumRodjenja = pacijent.DatumRodjenja,
                Telefon = pacijent.Telefon,
                Drzava = pacijent.Drzava,
                Grad = pacijent.Grad,
                Adresa = pacijent.Adresa,
                Email = pacijent.Email,
                KorisnikId = pacijent.KorisnikId,
            };

            return Ok(GetPacijentDto);
        }

        [HttpPost("addPacijent")]
        public async Task<IActionResult> AddPacijent(PacijentDto pacijentDto)
        {

            var pacijent = new Pacijent
            {
                Ime = pacijentDto.Ime,
                Prezime = pacijentDto.Prezime,
                Pol = pacijentDto.Pol,
                DatumRodjenja = pacijentDto.DatumRodjenja,
                Drzava = pacijentDto.Drzava,
                Grad = pacijentDto.Grad,
                Adresa = pacijentDto.Adresa,
                Telefon = pacijentDto.Telefon,
                Email = pacijentDto.Email,
                KorisnikId = pacijentDto.KorisnikId,
            };

            uow.PacijentRepository.AddPacijent(pacijent);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("DeletePacijent/{id}")]
        public async Task<IActionResult> DeletePacijent(int id)
        {
             uow.PacijentRepository.DeletePacijent(id);

            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("editPacijent/{id}")]
        public async Task<IActionResult> EditPacijent(int id, UpdatePacijentDto pacijentDto)
        {
            var pacijent = await uow.PacijentRepository.GetPacijentAsync(id);

            if (pacijent == null)
            {
                return NotFound();
            }

            pacijent.Ime = pacijentDto.Ime;
            pacijent.Prezime = pacijentDto.Prezime;
            pacijent.Pol = pacijentDto.Pol;
            pacijent.DatumRodjenja = pacijentDto.DatumRodjenja;
            pacijent.Drzava = pacijentDto.Drzava;
            pacijent.Grad = pacijentDto.Grad;
            pacijent.Adresa = pacijentDto.Adresa;
            pacijent.Telefon = pacijentDto.Telefon;
            pacijent.Email = pacijentDto.Email;

            uow.PacijentRepository.UpdatePacijent(pacijent);
            await uow.SaveAsync();

            return StatusCode(201);
        }

    }
}
