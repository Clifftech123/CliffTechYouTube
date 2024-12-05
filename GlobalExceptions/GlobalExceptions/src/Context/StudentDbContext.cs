using GlobalExceptions.src.Modles;
using Microsoft.EntityFrameworkCore;

namespace GlobalExceptions.src.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
