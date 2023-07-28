using backend.Dtos;
using MediatR;

namespace backend.Queries.TerminQueries
{
    public class GetTerminiQuery : IRequest<List<GetTerminiDto>>
    {
    }
}
