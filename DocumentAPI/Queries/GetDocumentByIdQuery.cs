using DocumentAPI.Dto;
using MediatR;

namespace DocumentAPI.Queries
{
    public class GetDocumentByIdQuery : IRequest<DocumentDto> 
    {
        public Guid Id { get; }
        public GetDocumentByIdQuery (Guid id) 
        {
            Id = id;
        }
    }
}
