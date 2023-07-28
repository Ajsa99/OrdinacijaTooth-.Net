using backend.Dtos;
using MediatR;

namespace backend.Commands.PacijentCommands
{
    public class EditPacijentCommand : IRequest
    {
        public int Id { get; set; }
        public UpdatePacijentDto PacijentDto { get; set; }

        public EditPacijentCommand(int id, UpdatePacijentDto pacijentDto)
        {
            Id = id;
            PacijentDto = pacijentDto;
        }
    }
}
