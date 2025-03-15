using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(ApplicationDbContext context): base(context)
        {
            
        }
        
    }
}
