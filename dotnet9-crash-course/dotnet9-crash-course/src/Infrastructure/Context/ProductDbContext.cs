using dotnet9_crash_course.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet9_crash_course.src.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }

}
