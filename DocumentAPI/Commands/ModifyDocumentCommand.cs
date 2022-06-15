using DocumentAPI.Dto;
using MediatR;

namespace DocumentAPI.Commands
{
    public class ModifyDocumentCommand : IRequest<bool>
    {
        public DocumentForEditDto Model { get; }
        public Guid Id { get; }
        public ModifyDocumentCommand(DocumentForEditDto model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
