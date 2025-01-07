using Microsoft.EntityFrameworkCore;
using RepositoryPattern.API.Domain.Entities;

namespace RepositoryPattern.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
