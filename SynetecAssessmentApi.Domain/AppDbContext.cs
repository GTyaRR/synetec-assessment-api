using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Entities;
using System.Reflection;

namespace SynetecAssessmentApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Employee>()
                .HasOne(w => w.Department)
                .WithMany(p => p.Employees)
                .HasForeignKey(w => w.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
