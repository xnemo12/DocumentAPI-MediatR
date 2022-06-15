using DocumentAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DocumentAPI.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Document> Document { get; set; }
    }
}
