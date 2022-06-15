using DocumentAPI.Filter;
using DocumentAPI.Models;

namespace DocumentAPI.Contracts
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAll(PaginationFilter filter);
        Task<Document> GetDocument(Guid Id);
        void UpdateDocument (Document document);
        void CreateDocument(Document document);
        void DeleteDocument(Document document);
    }
}
