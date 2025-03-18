using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _unitOfWork.Repository<User>().Add(user);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (user == null)
            {
                return 0;
            }
            _unitOfWork.Repository<User>().Delete(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return (List<User>)await _unitOfWork.Repository<User>().GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<User>().GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id, User user)
        {
            var _user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (_user == null)
            {
                return 0;
            }
            _user.Name = user.Name;
            _user.Email = user.Email;
            _user.Password = user.Password;
            return await _unitOfWork.CommitAsync();

        }

        public async Task<User?> Login(string email, string password)
        {
            var users = await _unitOfWork.Repository<User>().GetAllAsync();
            return users.FirstOrDefault(u => u.Email.Equals(email) && u.Password == password);
        }

    }
}
