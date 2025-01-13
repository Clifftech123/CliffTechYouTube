using Microsoft.EntityFrameworkCore;
using ScalarOpenApi.Domain.Models;

namespace ScalarOpenApi.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }


    }
}
