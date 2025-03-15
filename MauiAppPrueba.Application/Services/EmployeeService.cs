using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Domain.UnitOfWork;

namespace MauiAppPrueba.Application.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) 
        {            
            _unitOfWork = unitOfWork;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            var _employeeRepository = _unitOfWork.Repository<Employee>();
            await _employeeRepository.Add(employee);
            await _unitOfWork.CommitAsync();
            return employee;

        }

        public async Task<int> DeleteAsync(int id)
        {
            var _employeeRepository = _unitOfWork.Repository<Employee>();
            var employee = await _employeeRepository.GetByIdAsync(id);
            if(employee == null)
            {
                return 0;
            }
            _employeeRepository.Delete(employee);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var _employeeRepository = _unitOfWork.Repository<Employee>();
            return (List<Employee>)await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var _employeeRepository = _unitOfWork.Repository<Employee>();
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Employee employee)
        {
            var _employeeRepository = _unitOfWork.Repository<Employee>();
            var _employee = await _employeeRepository.GetByIdAsync(id);
            if (_employee == null)
            {
                return 0;
            }
            _employee.Name = employee.Name;
            _employee.Code = employee.Code;
            _employee.EntryDate = employee.EntryDate;
            _employee.Salary = employee.Salary;
            _employee.ImageUrl = employee.ImageUrl;

            _employeeRepository.Update(_employee);
            return await _unitOfWork.CommitAsync();
        }
    }
}
