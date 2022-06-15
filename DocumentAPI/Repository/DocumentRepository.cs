using DocumentAPI.Contracts;
using DocumentAPI.Filter;
using DocumentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentAPI.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void DeleteDocument(Document document)
        {
            Delete(document);
        }

        public async Task<IEnumerable<Document>> GetAll(PaginationFilter filter)
        {
            return await FindAll()
                .Skip((filter.Page - 1) * filter.PerPage)
                .Take(filter.PerPage)
                .OrderByDescending(d => d.CreatedDate)
                .ToListAsync();
        }

        public async Task<Document> GetDocument(Guid Id)
        {
            return await FindByCondition(d => d.Id == Id).FirstOrDefaultAsync();
        }

        public void UpdateDocument(Document document)
        {
            Update(document);
        }

        void IDocumentRepository.CreateDocument(Document document)
        {
            Create(document);
        }
    }
}
