using System.Data.Entity;
using PatientManagement.Data.Domain;

namespace PatientManagement.Data.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext") { }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // fluent API configuration
            modelBuilder.Entity<Patient>().Property(c => c.DateOfBirth).HasColumnType("date");
        }
    }
}
