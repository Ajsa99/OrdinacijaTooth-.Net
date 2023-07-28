using backend.Commands.PacijentCommands;
using backend.Interface;
using MediatR;

namespace backend.Handlers
{
    public class DeletePacijentHandler : IRequestHandler<DeletePacijentCommand>
    {
        private readonly IUnitOfWork uow;

        public DeletePacijentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Unit> Handle(DeletePacijentCommand request, CancellationToken cancellationToken)
        {
            uow.PacijentRepository.DeletePacijent(request.Id);
            await uow.SaveAsync();
            return Unit.Value;
        }
    }
}
