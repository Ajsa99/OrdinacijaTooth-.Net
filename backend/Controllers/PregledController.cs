using backend.Dtos;
using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregledController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public PregledController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        [HttpGet("getPregledi")]
        public async Task<IActionResult> GetPregledi()
        {
            var pregledi = await uow.PregledRepository.GetPreglediAsync();

            var GetPregledDto = from p in pregledi
                                select new GetPregledDto()
                                {
                                    Id = p.Id,
                                    BrojZuba = p.BrojZuba,
                                    GronjaVilicaBr = p.GronjaVilicaBr,
                                    DonjaVilicaBr = p.DonjaVilicaBr,
                                    GronjaVilicaStanje = p.GronjaVilicaStanje,
                                    DonjaVilicaStanje = p.DonjaVilicaStanje,
                                    Opis = p.Opis,
                                    TerminId = p.TerminId
                                };

            return Ok(GetPregledDto);
        }


        [HttpGet("getPregled/{id}")]
        public async Task<IActionResult> GetPregledAsync(int id)
        {
            var pregled = await uow.PregledRepository.GetPregledAsync(id);

            if (pregled == null)
            {
                return NotFound();
            }

            var GetPregledDto = new GetPregledDto()
            {
                Id = pregled.Id,
                BrojZuba = pregled.BrojZuba,
                GronjaVilicaBr = pregled.GronjaVilicaBr,
                DonjaVilicaBr = pregled.DonjaVilicaBr,
                GronjaVilicaStanje = pregled.GronjaVilicaStanje,
                DonjaVilicaStanje = pregled.DonjaVilicaStanje,
                Opis = pregled.Opis,
                TerminId = pregled.TerminId
            };

            return Ok(GetPregledDto);
        }

        [HttpPost("addPregled")]
        public async Task<IActionResult> AddPregled(PregledDto pregledDto)
        {

            var pregled = new Pregled
            {
                BrojZuba = pregledDto.BrojZuba,
                GronjaVilicaBr = pregledDto.GronjaVilicaBr,
                DonjaVilicaBr = pregledDto.DonjaVilicaBr,
                GronjaVilicaStanje = pregledDto.GronjaVilicaStanje,
                DonjaVilicaStanje = pregledDto.DonjaVilicaStanje,
                Opis = pregledDto.Opis,
                TerminId = pregledDto.TerminId
            };

            uow.PregledRepository.AddPregled(pregled);
            await uow.SaveAsync();
            return StatusCode(201);
        }

   

        [HttpGet("getTerminiPregledi/{idPacijent}")]
        public async Task<IActionResult> GetTerminiPregledi(int idPacijent)
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();
            var pregledi = await uow.PregledRepository.GetPreglediAsync();

            if (termini == null && pregledi == null)
            {
                return NotFound();
            }

            var GetTerminPregledDto = from termin in termini
                                      join pregled in pregledi on termin.Id equals pregled.TerminId
                                      where termin.PacijentId == idPacijent
                                      select new GetTerminPregledDto

                                      {
                                           PacijentId = termin.PacijentId,
                                           Datum = termin.Datum,
                                           Vreme = termin.Vreme,
                                           KorisnikId = termin.KorisnikId,
                                           BrojZuba = pregled.BrojZuba,
                                           GronjaVilicaBr = pregled.GronjaVilicaBr,
                                           DonjaVilicaBr = pregled.DonjaVilicaBr,
                                           GronjaVilicaStanje = pregled.GronjaVilicaStanje,
                                           DonjaVilicaStanje = pregled.DonjaVilicaStanje,
                                           Opis = pregled.Opis,
                                           TerminId = pregled.TerminId

                                       };

            return Ok(GetTerminPregledDto);
        }


        [HttpGet("getPacijentTerminiPregled/{idTermin}")]
        public async Task<IActionResult> GetPacijentTerminiPregled(int idTermin)
        {
            var termin = await uow.TerminRepository.GetTerminAsync(idTermin);
            if (termin == null)
            {
                return NotFound();
            }

            var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);
            if (pacijent == null)
            {
                return NotFound();
            }

            var pregled = await uow.PregledRepository.GetPregledAsync(termin.Id);

            var GetPacijentPregledTermin = new GetPacijentPregledTermin()
            {
                Id = termin.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                Datum = termin.Datum,
                Vreme = termin.Vreme,
                PacijentId = termin.PacijentId,
                KorisnikId = termin.KorisnikId,
                PregledId = pregled.Id,
                BrojZuba = pregled.BrojZuba,
                GronjaVilicaBr = pregled.GronjaVilicaBr,
                DonjaVilicaBr = pregled.DonjaVilicaBr,
                GronjaVilicaStanje = pregled.GronjaVilicaStanje,
                DonjaVilicaStanje = pregled.DonjaVilicaStanje,
                Opis = pregled.Opis,
                TerminId = pregled.TerminId
            };

            return Ok(GetPacijentPregledTermin);
        }

    }
}
