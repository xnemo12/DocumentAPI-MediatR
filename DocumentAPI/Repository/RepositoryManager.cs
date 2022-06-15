using DocumentAPI.Contracts;
using System;

namespace DocumentAPI.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IDocumentRepository> _document;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _document = new Lazy<IDocumentRepository>(() => new DocumentRepository(context));
        }

        IDocumentRepository IRepositoryManager.Document => _document.Value;
        public async Task SaveAsync() => await _context.SaveChangesAsync();    
    }
}
