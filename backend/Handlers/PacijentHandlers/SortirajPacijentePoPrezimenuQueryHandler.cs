using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PacijentQueries;
using MediatR;

namespace backend.Handlers.PacijentHandlers
{
    public class SortirajPacijentePoPrezimenuQueryHandler : IRequestHandler<SortirajPacijentePoPrezimenuQuery, List<PacijentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SortirajPacijentePoPrezimenuQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<PacijentDto>> Handle(SortirajPacijentePoPrezimenuQuery request, CancellationToken cancellationToken)
        {
            var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            var pacijentiDto = mapper.Map<List<PacijentDto>>(pacijenti);

            // Sortiranje pacijenata po prezimenu (abecedno)
            var sortiraniPacijenti = pacijentiDto.OrderBy(p => p.Prezime).ToList();

            return sortiraniPacijenti;
        }
    }

}
