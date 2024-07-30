using EmployeesInformation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesDataStore _employeesDataStore;

        public EmployeesController(EmployeesDataStore employeesDataStore)
        {
            _employeesDataStore = employeesDataStore;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeesDataStore.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee? employee = await _employeesDataStore.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employee)
        {
            Employee emp = new Employee { Name = employee.Name, JobTitle = employee.JobTitle, Salary =  employee.Salary };
            var id = await _employeesDataStore.CreateEmployee(emp);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _employeesDataStore.DeleteEmployeeById(id);
        }
    }
}
