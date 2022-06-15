using DocumentAPI.Commands;
using DocumentAPI.Contracts;
using MediatR;

namespace DocumentAPI.Handlers
{
    public class PublishDocumentCommandHandler : IRequestHandler<PublishDocumentCommand, bool>
    {
        private readonly IRepositoryManager _repository;
        public PublishDocumentCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PublishDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _repository.Document.GetDocument(request.Id);

            if (document != null) 
            {
                document.Status = Models.Status.Published;
                _repository.Document.UpdateDocument(document);
                await _repository.SaveAsync();

                return true;
            }

            return false;
        }
    }
}
