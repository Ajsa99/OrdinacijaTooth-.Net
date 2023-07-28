using backend.Dtos;
using backend.Interface;
using backend.Queries.TerminQueries;
using MediatR;

namespace backend.Handlers.TerminHandlers
{
    public class GetTerminiPacijentiHandler : IRequestHandler<GetTerminiPacijentiQuery, List<GetTerminPacijentDto>>
    {
        private readonly IUnitOfWork uow;

        public GetTerminiPacijentiHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<List<GetTerminPacijentDto>> Handle(GetTerminiPacijentiQuery request, CancellationToken cancellationToken)
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();
            var pacijenti = await uow.PacijentRepository.GetPacijentiAsync();

            if (termini == null || pacijenti == null)
            {
                return null;
            }

            var GetTerminPacijentDto = from termin in termini
                                       join pacijent in pacijenti on termin.PacijentId equals pacijent.Id
                                       select new GetTerminPacijentDto
                                       {
                                           Id = termin.Id,
                                           Ime = pacijent.Ime,
                                           Prezime = pacijent.Prezime,
                                           PacijentId = termin.PacijentId,
                                           Datum = termin.Datum,
                                           Vreme = termin.Vreme,
                                           KorisnikId = termin.KorisnikId
                                       };

            return GetTerminPacijentDto.ToList();
        }
    }
}
