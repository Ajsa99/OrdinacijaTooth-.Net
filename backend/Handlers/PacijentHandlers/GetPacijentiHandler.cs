using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class GetPacijentiHandler : IRequestHandler<GetPacijentiQuery, List<GetPacijentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPacijentiHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetPacijentDto>> Handle(GetPacijentiQuery request, CancellationToken cancellationToken)
        {
            var pacijent = await uow.PacijentRepository.GetPacijentiAsync();

            return mapper.Map<List<GetPacijentDto>>(pacijent);
        }
    }
}
