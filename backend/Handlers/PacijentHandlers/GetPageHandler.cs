using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Model;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class GetPageHandler : IRequestHandler<GetPageQuery, List<GetPacijentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPageHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetPacijentDto>> Handle(GetPageQuery request, CancellationToken cancellationToken)
        {
            var pacijent = await uow.PacijentRepository.Page(request.page, request.pageSize, request.id);
            return mapper.Map<List<GetPacijentDto>>(pacijent);
        }
    }
}
