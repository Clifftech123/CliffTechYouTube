using Microsoft.EntityFrameworkCore;
using QueryableIEnumerableAPI.Model;

namespace QueryableIEnumerableAPI.Data;

public class AppDbContext :DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Employee> Employees  => Set<Employee>();
}