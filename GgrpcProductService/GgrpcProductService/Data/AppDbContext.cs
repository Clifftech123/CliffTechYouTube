using GgrpcProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace GgrpcProductService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Products> Products => Set<Products>();
}