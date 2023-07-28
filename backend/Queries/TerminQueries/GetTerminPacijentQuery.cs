using backend.Dtos;
using MediatR;

namespace backend.Queries.TerminQueries
{
    public class GetTerminPacijentQuery : IRequest<GetTerminPacijentDto>
    {
        public int TerminId { get; set; }

        public GetTerminPacijentQuery(int terminId)
        {
            TerminId = terminId;
        }
    }
}
