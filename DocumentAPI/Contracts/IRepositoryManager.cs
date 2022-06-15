namespace DocumentAPI.Contracts
{
    public interface IRepositoryManager
    {
        IDocumentRepository Document { get; }
        Task SaveAsync();
    }
}
