using backend.Dtos;
using backend.Interface;
using backend.Queries.PregledQueries;
using MediatR;

namespace backend.Handlers.PregledHandlers
{
    public class GetTerminiPreglediHandler : IRequestHandler<GetTerminiPreglediQuery, List<GetTerminPregledDto>>
    {
        private readonly IUnitOfWork uow;

        public GetTerminiPreglediHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<List<GetTerminPregledDto>> Handle(GetTerminiPreglediQuery request, CancellationToken cancellationToken)
        {
            var termini = await uow.TerminRepository.GetTerminiAsync();
            var pregledi = await uow.PregledRepository.GetPreglediAsync();

            var GetTerminPregledDto = from termin in termini
                                      join pregled in pregledi on termin.Id equals pregled.TerminId
                                      where termin.PacijentId == request.IdPacijent
                                      select new GetTerminPregledDto
                                      {
                                          PacijentId = termin.PacijentId,
                                          Datum = termin.Datum,
                                          Vreme = termin.Vreme,
                                          KorisnikId = termin.KorisnikId,
                                          BrojZuba = pregled.BrojZuba,
                                          GronjaVilicaBr = pregled.GronjaVilicaBr,
                                          DonjaVilicaBr = pregled.DonjaVilicaBr,
                                          GronjaVilicaStanje = pregled.GronjaVilicaStanje,
                                          DonjaVilicaStanje = pregled.DonjaVilicaStanje,
                                          Opis = pregled.Opis,
                                          TerminId = pregled.TerminId
                                      };

            return GetTerminPregledDto.ToList();
        }
    }
}

