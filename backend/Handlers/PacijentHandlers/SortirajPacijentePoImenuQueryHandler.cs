using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class SortirajPacijentePoImenuQueryHandler : IRequestHandler<SortirajPacijentePoImenuQuery, List<PacijentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SortirajPacijentePoImenuQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<PacijentDto>> Handle(SortirajPacijentePoImenuQuery request, CancellationToken cancellationToken)
        {
            var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            var pacijentiDto = mapper.Map<List<PacijentDto>>(pacijenti);

            // Sortiranje pacijenata po imenu (abecedno)
            var sortiraniPacijenti = pacijentiDto.OrderBy(p => p.Ime).ToList();

            return sortiraniPacijenti;
        }
    }

}
