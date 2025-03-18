using MauiAppPrueba.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MauiAppPrueba.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; } = default!;
    }
}
