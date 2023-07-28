using AutoMapper;
using backend.Commands;
using backend.Commands.PacijentCommands;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;
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
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PacijentController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet("getPacijenti")]
        public async Task<IActionResult> GetPacijenti()
        {

            var query = new GetPacijentiQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPacijent/{id}")]
        public async Task<IActionResult> GetPacijent(int id)
        {
            var query = new GetPacijentIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);

            //var pacijent = await uow.PacijentRepository.GetPacijentAsync(id);

            //if (pacijent == null)
            //{
            //    return NotFound(); // Ako zahtev sa datim ID-om ne postoji, vraćamo NotFound status
            //}

            //var GetPacijentDto = mapper.Map<GetPacijentDto>(pacijent);

            //return Ok(GetPacijentDto);
        }

        [HttpPost("addPacijent")]
        public async Task<IActionResult> AddPacijent(PacijentDto pacijentDto)
        {
            var command = new CreatePacijentCommand(pacijentDto);
            var result = await mediator.Send(command);
            return Ok(result);

            //var pacijent = mapper.Map<Pacijent>(pacijentDto);

            //uow.PacijentRepository.AddPacijent(pacijent);
            //await uow.SaveAsync();
            //return StatusCode(201);
        }

        [HttpDelete("DeletePacijent/{id}")]
        public async Task<IActionResult> DeletePacijent(int id)
        {
            var command = new DeletePacijentCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);

            //uow.PacijentRepository.DeletePacijent(id);

            //await uow.SaveAsync();
            //return StatusCode(201);
        }

        [HttpPut("editPacijent/{id}")]
        public async Task<IActionResult> EditPacijent(int id, UpdatePacijentDto pacijentDto)
        {
            var command = new EditPacijentCommand(id, pacijentDto);
            var result = await mediator.Send(command);

            return Ok(result);
            //var pacijent = await uow.PacijentRepository.GetPacijentAsync(id);

            //if (pacijent == null)
            //{
            //    return NotFound();
            //}

            //mapper.Map(pacijentDto, pacijent);

            //uow.PacijentRepository.UpdatePacijent(pacijent);
            //await uow.SaveAsync();

            //return StatusCode(201);
        }

        [HttpGet("FilterPacijent/{imePrezime}")]
        public async Task<IActionResult> GetPacijenti(string imePrezime, [FromServices] IMediator mediator)
        {
            var query = new FilterPacijentiQuery { ImePrezime = imePrezime };
            var result = await mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("sortPacijentiIme")]
        public async Task<IActionResult> SortPacijentiIme([FromServices] IMediator mediator)
        {
            var query = new SortirajPacijentePoImenuQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("sortPacijentiPrezime")]
        public async Task<IActionResult> SortPacijentiPrezime([FromServices] IMediator mediator)
        {
            var query = new SortirajPacijentePoPrezimenuQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("Pacijenti/Page/{page}/{pageSize}/{id}")]
        public async Task<IActionResult> GetPacijenti(int page, int pageSize, int id)
        {
            var query = new GetPageQuery(page, pageSize, id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

    }
}
