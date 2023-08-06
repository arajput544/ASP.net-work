

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineWithEF
{
    class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //test
            //Console.WriteLine(config["TesterSection:testProperty"]);
            //Console.WriteLine(config.GetConnectionString("Default"));

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("Default"))
                .UseLazyLoadingProxies();
        }
        public DbSet<Vaccine> Vaccines { get; set; }
    }
}
