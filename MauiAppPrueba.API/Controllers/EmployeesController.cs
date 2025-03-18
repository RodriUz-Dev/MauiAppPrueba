using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MauiAppPrueba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeesController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Employee employee)
        {
            var newEmployee = await _employeeService.CreateAsync(employee);
            if (newEmployee == null)
            {
                return BadRequest();
            }
            return Ok(newEmployee);
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Employee employee)
        {
            var result = await _employeeService.UpdateAsync(id, employee);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
