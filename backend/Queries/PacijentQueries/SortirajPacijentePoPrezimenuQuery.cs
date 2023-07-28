using backend.Dtos;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class SortirajPacijentePoPrezimenuQuery : IRequest<List<PacijentDto>>
    {
    }

}
