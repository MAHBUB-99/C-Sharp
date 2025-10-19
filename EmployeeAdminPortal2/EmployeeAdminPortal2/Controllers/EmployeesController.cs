using EmployeeAdminPortal2.Data;
using EmployeeAdminPortal2.Models;
using EmployeeAdminPortal2.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var newEmployee = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Add(newEmployee);
            dbContext.SaveChanges();
            return Ok(newEmployee);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if(existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(existingEmployee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if(existingEmployee == null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(existingEmployee);
            dbContext.SaveChanges();
            return Ok(existingEmployee);
        }
    }
}
