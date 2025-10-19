🧩 Step-by-Step Procedure to Build the Employee CRUD API
---
## Create a new Web API project

-Open Visual Studio

-Click Create a new project

-Choose ASP.NET Core Web API

-Name it: EmployeeAdminPortal2

-Choose .NET 8.0 (or 7.0 if that’s what you have)

-Click Create

✅ This will generate a basic Web API structure.

## Create the Folder Structure

Inside your project:

EmployeeAdminPortal2/
 ┣ Controllers/
 ┣ Data/
 ┣ Models/
 ┃ ┣ Entities/
 ┃ ┗ DTOs/
 ┗ Program.cs

## Create the Employee Entity

Create file:
📁 Models/Entities/Employee.cs

namespace EmployeeAdminPortal2.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }  // Primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}


✅ This represents one row in the Employees table.

## Install Entity Framework Core Packages

Open Package Manager Console (PMC):

PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
PM> Install-Package Microsoft.EntityFrameworkCore.Tools


✅ These are needed to connect and manage SQL Server databases.

## Create ApplicationDbContext

Create file:
📁 Data/ApplicationDbContext.cs

using EmployeeAdminPortal2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 👇 This creates a table named Employees
        public DbSet<Employee> Employees { get; set; }
    }
}


✅ DbSet<Employee> represents the table.

## Configure Database Connection

Open appsettings.json and add your connection string:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=EmployeeAdminPortalDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

## Register DbContext in Program.cs

Open Program.cs and add:

using EmployeeAdminPortal2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();


✅ Now your app knows how to connect to SQL Server.

## Add DTOs (Data Transfer Objects)

Create folder 📁 Models/ → inside it make AddEmployeeDto.cs and UpdateEmployeeDto.cs

AddEmployeeDto.cs

namespace EmployeeAdminPortal2.Models
{
    public class AddEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}


UpdateEmployeeDto.cs

namespace EmployeeAdminPortal2.Models
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}


✅ DTOs are used to receive or send data from the API without exposing your entity directly.

## Add Migration & Create Database

Open Package Manager Console again and run:

PM> Add-Migration InitialCreate
PM> Update-Database


✅ This will create the database and the Employees table automatically.

## Create EmployeesController

Create file:
📁 Controllers/EmployeesController.cs

Paste this code:

using EmployeeAdminPortal2.Data;
using EmployeeAdminPortal2.Models;
using EmployeeAdminPortal2.Models.Entities;
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

        // GET all employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }

        // GET employee by id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST (Add new)
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

            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();

            return Ok(newEmployee);
        }

        // PUT (Update)
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if (existingEmployee == null)
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

        // DELETE
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(existingEmployee);
            dbContext.SaveChanges();

            return Ok(existingEmployee);
        }
    }
}


✅ This controller covers all CRUD operations:

GET /api/employees → Get all

GET /api/employees/{id} → Get one

POST /api/employees → Add new

PUT /api/employees/{id} → Update

DELETE /api/employees/{id} → Delete