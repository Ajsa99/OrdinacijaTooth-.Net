using backend.Dtos;
using MediatR;

namespace backend.Queries.PregledQueries
{
    public class GetPacijentTerminiPregledQuery : IRequest<GetPacijentPregledTermin>
    {
        public int IdTermin { get; set; }

        public GetPacijentTerminiPregledQuery(int idTermin)
        {
            IdTermin = idTermin;
        }
    }
}
