using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MauiAppPrueba.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        //public async Task<User>? LoginAsync(string email, string password)
        //{           
        //    var user = await _dbSet.FromSqlRaw("SELECT * FROM Users WHERE Email = {0} AND Password = {1}", email, password).FirstOrDefaultAsync();
        //    if (user != null)
        //    {
        //        return user;
        //    }
        //    return null;

        //}
    }
}
