using DocumentAPI.Dto;
using MediatR;

namespace DocumentAPI.Commands
{
    public class AddDocumentCommand : IRequest<Guid>
    {
        public DocumentForEditDto Model { get; }
        public AddDocumentCommand(DocumentForEditDto model)
        {
            Model = model;
        }
    }
}
