using VaccinePatientManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace VaccinePatientManagement.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Patient> Patients { get; set; }
       

    }
}
