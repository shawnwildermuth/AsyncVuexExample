using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VueValidation.Data
{
  public class CustomerContext : DbContext
  {
    private readonly IConfiguration _config;

    public CustomerContext(DbContextOptions opt, IConfiguration config) : base(opt)
    {
      _config = config;
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config.GetConnectionString("CustomerDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Customer>().HasData(
        new Customer()
        {
          Id = 1,
          CompanyName = "Wilder Minds LLC",
          ContactName = "Shawn Wildermuth",
          AddressLine1 = "123 Main Street",
          CityTown = "Atlanta",
          StateProvince = "GA",
          PostalCode = "12345",
          Country = "USA",
          Phone = "404-555-1212"
        },
        new Customer()
        {
          Id = 2,
          CompanyName = "Hello World Film",
          ContactName = "Jake Smith",
          AddressLine1 = "123 Main Street",
          CityTown = "Atlanta",
          StateProvince = "GA",
          PostalCode = "12345",
          Country = "USA",
          Phone = "404-555-1212"
        }
        );
    }
  }
}
