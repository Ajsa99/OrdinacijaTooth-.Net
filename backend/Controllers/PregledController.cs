using AutoMapper;
using backend.Commands.PregledCommands;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PregledQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregledController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PregledController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet("getPregledi")]
        public async Task<IActionResult> GetPregledi()
        {
            var query = new GetPreglediQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("getPregled/{id}")]
        public async Task<IActionResult> GetPregledAsync(int id)
        {
            var query = new GetPregledByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("addPregled")]
        public async Task<IActionResult> AddPregled(PregledDto pregledDto)
        {
            var command = new CreatePregledCommand(pregledDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }

   

        [HttpGet("getTerminiPregledi/{idPacijent}")]
        public async Task<IActionResult> GetTerminiPregledi(int idPacijent)
        {
            var query = new GetTerminiPreglediQuery(idPacijent);
            var result = await mediator.Send(query);
            return Ok(result);


            //var termini = await uow.TerminRepository.GetTerminiAsync();
            //var pregledi = await uow.PregledRepository.GetPreglediAsync();

            //if (termini == null && pregledi == null)
            //{
            //    return NotFound();
            //}

            //var GetTerminPregledDto = from termin in termini
            //                          join pregled in pregledi on termin.Id equals pregled.TerminId
            //                          where termin.PacijentId == idPacijent
            //                          select new GetTerminPregledDto

            //                          {
            //                               PacijentId = termin.PacijentId,
            //                               Datum = termin.Datum,
            //                               Vreme = termin.Vreme,
            //                               KorisnikId = termin.KorisnikId,
            //                               BrojZuba = pregled.BrojZuba,
            //                               GronjaVilicaBr = pregled.GronjaVilicaBr,
            //                               DonjaVilicaBr = pregled.DonjaVilicaBr,
            //                               GronjaVilicaStanje = pregled.GronjaVilicaStanje,
            //                               DonjaVilicaStanje = pregled.DonjaVilicaStanje,
            //                               Opis = pregled.Opis,
            //                               TerminId = pregled.TerminId

            //                           };

            //return Ok(GetTerminPregledDto);
        }


        [HttpGet("getPacijentTerminiPregled/{idTermin}")]
        public async Task<IActionResult> GetPacijentTerminiPregled(int idTermin)
        {
            var query = new GetPacijentTerminiPregledQuery(idTermin);
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

            //var termin = await uow.TerminRepository.GetTerminAsync(idTermin);
            //if (termin == null)
            //{
            //    return NotFound();
            //}

            //var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);
            //if (pacijent == null)
            //{
            //    return NotFound();
            //}

            //var pregled = await uow.PregledRepository.GetPregledAsync(termin.Id);

            //var GetPacijentPregledTermin = new GetPacijentPregledTermin()
            //{
            //    Id = termin.Id,
            //    Ime = pacijent.Ime,
            //    Prezime = pacijent.Prezime,
            //    Datum = termin.Datum,
            //    Vreme = termin.Vreme,
            //    PacijentId = termin.PacijentId,
            //    KorisnikId = termin.KorisnikId,
            //    PregledId = pregled.Id,
            //    BrojZuba = pregled.BrojZuba,
            //    GronjaVilicaBr = pregled.GronjaVilicaBr,
            //    DonjaVilicaBr = pregled.DonjaVilicaBr,
            //    GronjaVilicaStanje = pregled.GronjaVilicaStanje,
            //    DonjaVilicaStanje = pregled.DonjaVilicaStanje,
            //    Opis = pregled.Opis,
            //    TerminId = pregled.TerminId
            //};

            //return Ok(GetPacijentPregledTermin);
        }

    }
}
