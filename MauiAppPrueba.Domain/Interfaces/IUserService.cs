using MauiAppPrueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<int> UpdateAsync(int id, User user);
        Task<int> DeleteAsync(int id);
        Task<User?> Login(string email, string password);
    }
}
