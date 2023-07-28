using AutoMapper;
using backend.Commands.PregledCommands;
using backend.Dtos;
using backend.Interface;
using backend.Model;
using MediatR;

namespace backend.Handlers.PregledHandlers
{
    public class CreatePregledHandler : IRequestHandler<CreatePregledCommand, Pregled>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreatePregledHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Pregled> Handle(CreatePregledCommand request, CancellationToken cancellationToken)
        {
            var pregled = mapper.Map<Pregled>(request.pregledDto);

            uow.PregledRepository.AddPregled(pregled);
            await uow.SaveAsync();
            return pregled;
        }
    }
}
