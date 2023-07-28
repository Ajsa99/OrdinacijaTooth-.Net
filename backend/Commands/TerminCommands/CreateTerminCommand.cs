using backend.Dtos;
using backend.Model;
using MediatR;

namespace backend.Commands.TerminCommands
{
    public class CreateTerminCommand : IRequest<Termin>
    {
        public TerminDto terminDto { get; set; }
        public CreateTerminCommand(TerminDto terminDto)
        {
            this.terminDto = terminDto;
        }
    }
}
