using backend.Dtos;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class FilterPacijentiQuery : IRequest<List<PacijentDto>>
    {
        public string ImePrezime { get; set; }
    }

}
