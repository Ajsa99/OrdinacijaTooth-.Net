using backend.Dtos;
using MediatR;

namespace backend.Queries.PregledQueries
{
    public class GetTerminiPreglediQuery : IRequest<List<GetTerminPregledDto>>
    {
        public int IdPacijent { get; set; }

        public GetTerminiPreglediQuery(int idPacijent)
        {
            IdPacijent = idPacijent;
        }
    }
}

