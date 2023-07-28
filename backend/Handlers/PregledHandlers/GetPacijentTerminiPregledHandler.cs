using backend.Dtos;
using backend.Interface;
using backend.Queries.PregledQueries;
using MediatR;

namespace backend.Handlers.PregledHandlers
{
    public class GetPacijentTerminiPregledHandler : IRequestHandler<GetPacijentTerminiPregledQuery, GetPacijentPregledTermin>
    {
        private readonly IUnitOfWork uow;

        public GetPacijentTerminiPregledHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<GetPacijentPregledTermin> Handle(GetPacijentTerminiPregledQuery request, CancellationToken cancellationToken)
        {
            var termin = await uow.TerminRepository.GetTerminAsync(request.IdTermin);
            if (termin == null)
            {
                return null;
            }

            var pacijent = await uow.PacijentRepository.GetPacijentAsync(termin.PacijentId);
            if (pacijent == null)
            {
                return null;
            }

            var pregled = await uow.PregledRepository.GetPregledAsync(termin.Id);

            var GetPacijentPregledTermin = new GetPacijentPregledTermin()
            {
                Id = termin.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                Datum = termin.Datum,
                Vreme = termin.Vreme,
                PacijentId = termin.PacijentId,
                KorisnikId = termin.KorisnikId,
                PregledId = pregled.Id,
                BrojZuba = pregled.BrojZuba,
                GronjaVilicaBr = pregled.GronjaVilicaBr,
                DonjaVilicaBr = pregled.DonjaVilicaBr,
                GronjaVilicaStanje = pregled.GronjaVilicaStanje,
                DonjaVilicaStanje = pregled.DonjaVilicaStanje,
                Opis = pregled.Opis,
                TerminId = pregled.TerminId
            };

            return GetPacijentPregledTermin;
        }
    }
}
