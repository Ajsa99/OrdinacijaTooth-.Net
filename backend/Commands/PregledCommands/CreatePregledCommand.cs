using backend.Dtos;
using backend.Model;
using MediatR;

namespace backend.Commands.PregledCommands
{
    public class CreatePregledCommand : IRequest<Pregled>
    {
        public PregledDto pregledDto { get; set; }
        public CreatePregledCommand(PregledDto PregledDto)
        {
            this.pregledDto = PregledDto;
        }
    }
}
