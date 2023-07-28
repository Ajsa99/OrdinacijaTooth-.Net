using backend.Dtos;
using backend.Model;
using MediatR;

namespace backend.Queries.PacijentQueries
{
    public class GetPageQuery : IRequest<List<GetPacijentDto>>
    {
        public int page { get; }
        public int pageSize { get; }
        public int id { get; }

        public GetPageQuery(int Page, int PageSize, int Id)
        {
            page = Page;
            pageSize = PageSize;
            id = Id;
        }
    }
}
