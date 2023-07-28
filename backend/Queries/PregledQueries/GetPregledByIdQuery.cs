using backend.Dtos;
using MediatR;

namespace backend.Queries.PregledQueries
{
    public class GetPregledByIdQuery : IRequest<GetPregledDto>
    {
        public int Id { get; set; }

        public GetPregledByIdQuery(int id)
        {
            Id = id;
        }
    }
}
