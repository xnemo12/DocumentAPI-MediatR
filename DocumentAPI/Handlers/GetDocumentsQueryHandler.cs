using AutoMapper;
using DocumentAPI.Contracts;
using DocumentAPI.Dto;
using DocumentAPI.Queries;
using MediatR;

namespace DocumentAPI.Handlers
{
    public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, IEnumerable<DocumentDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetDocumentsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _repository.Document.GetAll(request.Filter);
            var documentsDto = _mapper.Map<IEnumerable<DocumentDto>>(documents);
            return documentsDto;
        }
    }
}
