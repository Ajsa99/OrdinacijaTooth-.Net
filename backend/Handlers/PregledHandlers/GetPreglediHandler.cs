using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Model;
using backend.Queries.PregledQueries;
using MediatR;

namespace backend.Handlers.PregledHandlers
{
    public class GetPreglediHandler : IRequestHandler<GetPreglediQuery, List<GetPregledDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPreglediHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetPregledDto>> Handle(GetPreglediQuery request, CancellationToken cancellationToken)
        {
            var pregledi = await uow.PregledRepository.GetPreglediAsync();

            return mapper.Map<List<GetPregledDto>>(pregledi);
        }
    }
}
