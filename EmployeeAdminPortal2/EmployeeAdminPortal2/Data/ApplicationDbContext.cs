using EmployeeAdminPortal2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
