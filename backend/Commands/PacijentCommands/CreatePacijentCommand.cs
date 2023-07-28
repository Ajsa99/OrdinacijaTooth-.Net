using backend.Dtos;
using backend.Model;
using MediatR;

namespace backend.Commands.PacijentCommands
{
    public class CreatePacijentCommand : IRequest<Pacijent>
    {
        public PacijentDto pacijentDto { get; set; }
        public CreatePacijentCommand(PacijentDto pacijentDto)
        {
            this.pacijentDto = pacijentDto;
        }
    }
}
