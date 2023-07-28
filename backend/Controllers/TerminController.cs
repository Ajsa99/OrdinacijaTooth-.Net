using AutoMapper;
using backend.Commands.TerminCommands;
using backend.Dtos;
using backend.Interface;
using backend.Queries.TerminQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public TerminController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet("getTermini")]
        public async Task<IActionResult> GetTermini()
        {
            var query = new GetTerminiQuery();
            var result = await mediator.Send(query);
            return Ok(result);

            //var termini = await uow.TerminRepository.GetTerminiAsync();

            //var GetTerminDto = mapper.Map<IEnumerable<GetTerminiDto>>(termini);

            //return Ok(GetTerminDto);
        }

        [HttpGet("getTerminiPacijenti")]
        public async Task<IActionResult> GetTerminiPacijenti()
        {
            var query = new GetTerminiPacijentiQuery();
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

            //var termini = await uow.TerminRepository.GetTerminiAsync();
            //var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            //if (termini == null && pacijenti == null)
            //{
            //    return NotFound();
            //}

            //var GetTerminPacijentDto = from termin in termini
            //                    join pacijent in pacijenti on termin.PacijentId equals pacijent.Id
            //                    select new GetTerminPacijentDto
            //                    {
            //                        Id = termin.Id,
            //                        Ime = pacijent.Ime,
            //                        Prezime = pacijent.Prezime,
            //                        PacijentId = termin.PacijentId,
            //                        Datum = termin.Datum,
            //                        Vreme = termin.Vreme,
            //                        KorisnikId = termin.KorisnikId
            //                    };

            //return Ok(GetTerminPacijentDto);
        }

        [HttpGet("getTerminiPacijenti/{id}")]
        public async Task<IActionResult> GetTerminiPacijenti(int id)
        {
            var query = new GetTerminPacijentQuery(id);
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

            //var termin = await uow.TerminRepository.GetTerminAsync(id);
            //var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);

            //if (termin == null && pacijent == null)
            //{
            //    return NotFound();
            //}

            //var GetTerminPacijentDto = new GetTerminPacijentDto()
            //{
            //    Id = termin.Id,
            //    Ime = pacijent.Ime,
            //    Prezime = pacijent.Prezime,
            //    Datum = termin.Datum,
            //    Vreme = termin.Vreme,
            //    PacijentId = termin.PacijentId,
            //    KorisnikId = termin.KorisnikId
            //};

            //return Ok(GetTerminPacijentDto);
        }


        [HttpPost("addTermin")]
        public async Task<IActionResult> AddTermin(TerminDto terminDto)
        {
            var command = new CreateTerminCommand(terminDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
