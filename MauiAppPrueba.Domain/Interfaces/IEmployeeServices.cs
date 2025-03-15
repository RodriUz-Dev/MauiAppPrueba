using MauiAppPrueba.Domain.Entities;

namespace MauiAppPrueba.Domain.Interfaces
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<int> UpdateAsync(int id, Employee employee);
        Task<int> DeleteAsync(int id);
    }
}
