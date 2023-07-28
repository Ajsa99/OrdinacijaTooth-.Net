using AutoMapper;
using backend.Commands.PacijentCommands;
using backend.Interface;
using backend.Model;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class CreatePacijentHandler : IRequestHandler<CreatePacijentCommand, Pacijent>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreatePacijentHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Pacijent> Handle(CreatePacijentCommand request, CancellationToken cancellationToken)
        {
            var pacijent = mapper.Map<Pacijent>(request.pacijentDto);

            uow.PacijentRepository.AddPacijent(pacijent);
            await uow.SaveAsync();
            return pacijent;
        }
    }
}
