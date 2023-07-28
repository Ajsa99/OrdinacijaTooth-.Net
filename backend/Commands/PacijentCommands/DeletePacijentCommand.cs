using MediatR;

namespace backend.Commands.PacijentCommands
{
    public class DeletePacijentCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePacijentCommand(int id)
        {
            Id = id;
        }
    }
}
