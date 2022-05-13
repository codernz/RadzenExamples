using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using ImportCsvFiles.Models.CsvImportExample;

namespace ImportCsvFiles.Data
{
  public partial class CsvImportExampleContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public CsvImportExampleContext(DbContextOptions<CsvImportExampleContext> options):base(options)
    {
    }

    public CsvImportExampleContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        builder.Entity<ImportCsvFiles.Models.CsvImportExample.Customer>()
              .Property(p => p.CustomerID)
              .HasPrecision(10, 0);

        builder.Entity<ImportCsvFiles.Models.CsvImportExample.Customer>()
              .Property(p => p.ZipCode)
              .HasPrecision(10, 0);

        builder.Entity<ImportCsvFiles.Models.CsvImportExample.Customer>()
              .Property(p => p.Age)
              .HasPrecision(10, 0);

        builder.Entity<ImportCsvFiles.Models.CsvImportExample.CustomersStaging>()
              .Property(p => p.Customer_StagingID)
              .HasPrecision(10, 0);

        builder.Entity<ImportCsvFiles.Models.CsvImportExample.CustomersStaging>()
              .Property(p => p.ZipCode)
              .HasPrecision(10, 0);

        builder.Entity<ImportCsvFiles.Models.CsvImportExample.CustomersStaging>()
              .Property(p => p.Age)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<ImportCsvFiles.Models.CsvImportExample.Customer> Customers
    {
      get;
      set;
    }

    public DbSet<ImportCsvFiles.Models.CsvImportExample.CustomersStaging> CustomersStagings
    {
      get;
      set;
    }
  }
}
