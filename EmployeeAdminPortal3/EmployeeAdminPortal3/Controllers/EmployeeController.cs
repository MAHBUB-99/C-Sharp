using EmployeeAdminPortal3.Data;
using EmployeeAdminPortal3.Models.DTOs;
using EmployeeAdminPortal3.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _dbContext.EmployeesTable.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.EmployeesTable.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var NewEmployee = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            _dbContext.EmployeesTable.Add(NewEmployee);
            _dbContext.SaveChanges();
            return Ok(NewEmployee);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult updateEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = _dbContext.EmployeesTable.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;
            _dbContext.SaveChanges();
            return Ok("Updated.");
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = _dbContext.EmployeesTable.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _dbContext.EmployeesTable.Remove(existingEmployee);
            _dbContext.SaveChanges();
            return Ok("Deleted.");
        }
    }
}
