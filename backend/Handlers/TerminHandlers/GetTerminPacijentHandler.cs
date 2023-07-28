using backend.Dtos;
using backend.Interface;
using backend.Queries.TerminQueries;
using MediatR;

namespace backend.Handlers.TerminHandlers
{
    public class GetTerminPacijentHandler : IRequestHandler<GetTerminPacijentQuery, GetTerminPacijentDto>
    {
        private readonly IUnitOfWork uow;

        public GetTerminPacijentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<GetTerminPacijentDto> Handle(GetTerminPacijentQuery request, CancellationToken cancellationToken)
        {
            var termin = await uow.TerminRepository.GetTerminAsync(request.TerminId);
            if (termin == null)
            {
                return null; // Ovde možete baciti izuzetak ili vratiti odgovarajući rezultat ako termin nije pronađen
            }

            var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);
            if (pacijent == null)
            {
                return null; // Ovde možete baciti izuzetak ili vratiti odgovarajući rezultat ako pacijent nije pronađen
            }

            var GetTerminPacijentDto = new GetTerminPacijentDto()
            {
                Id = termin.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                Datum = termin.Datum,
                Vreme = termin.Vreme,
                PacijentId = termin.PacijentId,
                KorisnikId = termin.KorisnikId
            };

            return GetTerminPacijentDto;
        }
    }
}
