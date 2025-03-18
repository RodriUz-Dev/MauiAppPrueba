using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Infrastructure.Data;

namespace MauiAppPrueba.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(ApplicationDbContext context): base(context)
        {
            
        }
        
    }
}
