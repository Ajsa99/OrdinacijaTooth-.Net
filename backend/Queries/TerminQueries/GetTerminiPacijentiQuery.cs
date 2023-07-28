using backend.Dtos;
using MediatR;

namespace backend.Queries.TerminQueries
{
    public class GetTerminiPacijentiQuery : IRequest<List<GetTerminPacijentDto>>
    {
    }
}
