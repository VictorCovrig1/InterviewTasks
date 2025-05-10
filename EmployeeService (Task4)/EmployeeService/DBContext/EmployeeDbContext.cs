using EmployeeService.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.DBContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Function> Functions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(emp => emp.EmployeeId);
            modelBuilder.Entity<Department>().HasKey(emp => emp.DepartmentId);
            modelBuilder.Entity<Function>().HasKey(emp => emp.FunctionId);
        }
    }
}
