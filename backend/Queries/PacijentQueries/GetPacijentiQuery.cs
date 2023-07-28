using backend.Dtos;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class GetPacijentiQuery : IRequest<List<GetPacijentDto>>
    {
    }
}
