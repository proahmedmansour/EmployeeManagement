using Entities.Configuration;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Manager)
                    .WithMany(x => x.Employees)
                    .HasForeignKey(x => x.ManagerId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
