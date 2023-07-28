using backend.Dtos;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class SortirajPacijentePoImenuQuery : IRequest<List<PacijentDto>>
    {
    }

}
