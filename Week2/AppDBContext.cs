using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine;

namespace Week2
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
            Console.WriteLine(config["SomeProperty"]);
            Console.WriteLine(config["SomeSection:Property1"]);

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("Default"))
                .UseLazyLoadingProxies();
        }
        public DbSet<vaccine.Vaccine> Vaccines { get; set; }
    }
}
