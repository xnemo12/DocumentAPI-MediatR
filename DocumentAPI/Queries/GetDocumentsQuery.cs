using DocumentAPI.Dto;
using DocumentAPI.Filter;
using MediatR;

namespace DocumentAPI.Queries
{
    public class GetDocumentsQuery : IRequest<IEnumerable<DocumentDto>> 
    {
        public PaginationFilter Filter { get; }
        public GetDocumentsQuery(PaginationFilter filter)
        {
            Filter = filter;
        }
    }
}
