using DocumentAPI.Commands;
using DocumentAPI.Contracts;
using DocumentAPI.Dto;
using DocumentAPI.Models;
using MediatR;

namespace DocumentAPI.Handlers
{
    public class ModifyDocumentCommandHandler : IRequestHandler<ModifyDocumentCommand, bool>
    {
        private readonly IRepositoryManager _repository;

        public ModifyDocumentCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ModifyDocumentCommand request, CancellationToken cancellationToken)
        {
            DocumentForEditDto model = request.Model;

            var document = await _repository.Document.GetDocument(request.Id);
            if (document == null || document.Status == Status.Published)
                return false;

            document.Data = model.Data;
            document.ModifedDate = DateTime.Now;

            _repository.Document.UpdateDocument(document);
            await _repository.SaveAsync();

            return true;
        }
    }
}
