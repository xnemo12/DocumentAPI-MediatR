using AutoMapper;
using DocumentAPI.Contracts;
using DocumentAPI.Dto;
using DocumentAPI.Filter;
using DocumentAPI.Models;
using DocumentAPI.Queries;
using MediatR;

namespace DocumentAPI.Handlers
{
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, DocumentDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetDocumentByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<DocumentDto> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var document = await _repository.Document.GetDocument(request.Id);
            var documentDto = _mapper.Map<DocumentDto>(document);
            return documentDto;
        }
    }
}
