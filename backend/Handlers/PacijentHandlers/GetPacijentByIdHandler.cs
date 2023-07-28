using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class GetPacijentByIdHandler : IRequestHandler<GetPacijentIdQuery, GetPacijentDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPacijentByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<GetPacijentDto> Handle(GetPacijentIdQuery request, CancellationToken cancellationToken)
        {
            var pacijent = await uow.PacijentRepository.GetPacijentAsync(request.Id);

            return mapper.Map<GetPacijentDto>(pacijent);
        }
    }
}