using MediatR;

namespace DocumentAPI.Commands
{
    public class PublishDocumentCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public PublishDocumentCommand(Guid id)
        {
            Id = id;
        }
    }
}
