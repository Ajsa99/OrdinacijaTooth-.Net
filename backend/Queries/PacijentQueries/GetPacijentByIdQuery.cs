using backend.Dtos;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class GetPacijentIdQuery : IRequest<GetPacijentDto>
    {
        public int Id { get; set; }

        public GetPacijentIdQuery(int id)
        {
            Id = id;
        }
    }
}
