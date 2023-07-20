using backend.Dtos;
using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public TerminController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        [HttpGet("getTermini")]
        public async Task<IActionResult> GetTermini()
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();

            var GetTerminDto = from t in termini
                                 select new GetTerminiDto()
                                 {
                                     Id = t.Id,
                                     PacijentId = t.PacijentId,
                                     Datum = t.Datum,
                                     Vreme = t.Vreme,
                                     KorisnikId = t.KorisnikId
                                 };

            return Ok(GetTerminDto);
        }

        [HttpGet("getTerminiPacijenti")]
        public async Task<IActionResult> GetTerminiPacijenti()
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();
            var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            if (termini == null && pacijenti == null)
            {
                return NotFound();
            }

            var GetTerminPacijentDto = from termin in termini
                                join pacijent in pacijenti on termin.PacijentId equals pacijent.Id
                                select new GetTerminPacijentDto
                                {
                                    Id = termin.Id,
                                    Ime = pacijent.Ime,
                                    Prezime = pacijent.Prezime,
                                    PacijentId = termin.PacijentId,
                                    Datum = termin.Datum,
                                    Vreme = termin.Vreme,
                                    KorisnikId = termin.KorisnikId
                                };

            return Ok(GetTerminPacijentDto);
        }

        [HttpGet("getTerminiPacijenti/{id}")]
        public async Task<IActionResult> GetTerminiPacijenti(int id)
        {
            var termin = await uow.TerminRepository.GetTerminAsync(id);
            var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);

            if (termin == null && pacijent == null)
            {
                return NotFound();
            }

            var GetTerminPacijentDto = new GetTerminPacijentDto()
            {
                Id = termin.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                Datum = termin.Datum,
                Vreme = termin.Vreme,
                PacijentId = termin.PacijentId,
                KorisnikId = termin.KorisnikId
            };

            return Ok(GetTerminPacijentDto);
        }


        [HttpPost("addTermin")]
        public async Task<IActionResult> AddTermin(TerminDto terminDto)
        {

            var termin = new Termin
            {
                PacijentId = terminDto.PacijentId,
                Datum = terminDto.Datum,
                Vreme = terminDto.Vreme,
                KorisnikId = terminDto.KorisnikId,
            };

            uow.TerminRepository.AddTermin(termin);
            await uow.SaveAsync();
            return StatusCode(201);
        }
    }
}
