using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class FilterPacijentiQueryHandler : IRequestHandler<FilterPacijentiQuery, List<PacijentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public FilterPacijentiQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<PacijentDto>> Handle(FilterPacijentiQuery request, CancellationToken cancellationToken)
        {
            var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            var pacijentiDto = mapper.Map<List<PacijentDto>>(pacijenti);

            var filterPacijenti = pacijentiDto.Where(p =>
                p.Ime.IndexOf(request.ImePrezime, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.Prezime.IndexOf(request.ImePrezime, StringComparison.OrdinalIgnoreCase) >= 0);

            return filterPacijenti.ToList();
        }
    }

}
