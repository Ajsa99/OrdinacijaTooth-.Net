using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PregledQueries;
using backend.Queries.TerminQueries;
using MediatR;

namespace backend.Handlers.TerminHandlers
{
    public class GetTerminiHandler : IRequestHandler<GetTerminiQuery, List<GetTerminiDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetTerminiHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<GetTerminiDto>> Handle(GetTerminiQuery request, CancellationToken cancellationToken)
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();

            return mapper.Map<List<GetTerminiDto>>(termini);
        }
    }
}
