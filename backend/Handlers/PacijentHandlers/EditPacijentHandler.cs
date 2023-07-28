using AutoMapper;
using backend.Commands.PacijentCommands;
using backend.Interface;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class EditPacijentHandler : IRequestHandler<EditPacijentCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public EditPacijentHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(EditPacijentCommand request, CancellationToken cancellationToken)
        {
            var pacijent = await uow.PacijentRepository.GetPacijentAsync(request.Id);

            mapper.Map(request.PacijentDto, pacijent);

            uow.PacijentRepository.UpdatePacijent(pacijent);
            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}
