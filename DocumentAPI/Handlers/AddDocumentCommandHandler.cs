using DocumentAPI.Commands;
using DocumentAPI.Contracts;
using DocumentAPI.Dto;
using DocumentAPI.Models;
using MediatR;

namespace DocumentAPI.Handlers
{
    public class AddDocumentCommandHandler : IRequestHandler<AddDocumentCommand, Guid>
    {
        private readonly IRepositoryManager _repository;

        public AddDocumentCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            DocumentForEditDto model = request.Model;

            Document document = new Document { 
                Data = model.Data, 
                Status = Status.Draft,
                CreatedDate = DateTime.Now,
                ModifedDate = DateTime.Now
            };

            _repository.Document.CreateDocument(document);
            await _repository.SaveAsync();

            return document.Id;
        }
    }
}
