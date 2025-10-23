using EmployeeAdminPortal3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        public DbSet<Employee> EmployeesTable { get; set; }
       }
}
