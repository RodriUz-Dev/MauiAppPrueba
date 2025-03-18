using MauiAppPrueba.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppPrueba.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly string baseUri;
        private readonly IConfiguration _configuration;


        private List<Employee> employees = new List<Employee>();

        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUri = _configuration.GetSection("ApiBaseUrl")?.Value ?? string.Empty;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{baseUri}/employees");

            if (response.IsSuccessStatusCode)
            {
                //employees = await response.Content.ReadFromJsonAsync<List<Employee>>();
                employees = await response.Content.ReadFromJsonAsync<List<Employee>>() ?? new List<Employee>();
                if (employees == null)
                {
                    employees = new List<Employee>();
                    return employees;
                }
                return employees;
            }
            else
            {
                employees = new List<Employee>();
                return employees;

                
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{baseUri}/employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                var employee = await response.Content.ReadFromJsonAsync<Employee>();
                if (employee == null)
                {
                    employee = new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };
                    return employee;
                }
                return employee;
            }
            else
            {
                var employee = new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };
                return employee;

            }
        }

        public async Task<Employee> Create(Employee employee)
        {
            var client = new HttpClient();
            string json = JsonSerializer.Serialize(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUri}/employees", content);
            
            if (response.IsSuccessStatusCode)
            {
                var newEmployee = await response.Content.ReadFromJsonAsync<Employee>();

                if (newEmployee == null)
                {
                    return new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };
                }
                return newEmployee;
            }
            else
            {
                return new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };
            }

        }

        public async Task<Employee> Update(Employee employee)
        {
            var client = new HttpClient();
            string json = JsonSerializer.Serialize(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUri}/employees/{employee.Id}", content);
            if (response.IsSuccessStatusCode)
            {
                //var editEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                //if (editEmployee == null)
                //{
                //    return new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };
                //}
                return employee;
            }
            else
            {
                return new Employee() { Code = 0, Name = string.Empty, EntryDate = string.Empty, Salary = 0, ImageUrl = string.Empty };


            }
        }

        public async Task<bool> Delete(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUri}/employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
