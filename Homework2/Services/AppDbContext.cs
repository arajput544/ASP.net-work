using Homework2.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Vaccine> Vaccines { get; set; }
       

    }
}
