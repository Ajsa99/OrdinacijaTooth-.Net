using AutoMapper;
using backend.Commands.PregledCommands;
using backend.Commands.TerminCommands;
using backend.Interface;
using backend.Model;
using MediatR;

namespace backend.Handlers.TerminHandlers
{
    public class CreateTerminHandler : IRequestHandler<CreateTerminCommand, Termin>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreateTerminHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Termin> Handle(CreateTerminCommand request, CancellationToken cancellationToken)
        {

            var termin = mapper.Map<Termin>(request.terminDto);

            uow.TerminRepository.AddTermin(termin);
            await uow.SaveAsync();
            return termin;

        }
    }
}