using backend.Dtos;
using MediatR;

namespace backend.Queries.PregledQueries
{
    public class GetPreglediQuery : IRequest<List<GetPregledDto>>
    {
    }
}
