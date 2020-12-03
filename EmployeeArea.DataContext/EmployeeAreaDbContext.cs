using EmployeeArea.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeArea.DataContext
{
    public class EmployeeAreaDbContext : DbContext
    {
        public EmployeeAreaDbContext(DbContextOptions<EmployeeAreaDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobRegistration> JobRegistrations { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Delegation> Delegations { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging(true);
        //    optionsBuilder.UseSqlite(@"Data Source =..\EmployeeAreaDb.db");
        //}
    }
}
