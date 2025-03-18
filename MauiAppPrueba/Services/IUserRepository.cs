using MauiAppPrueba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Services
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);

        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<bool> Delete(int id);
    }
}
