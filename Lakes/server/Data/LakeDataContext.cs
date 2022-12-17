using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Lakes.Models.LakeData;

namespace Lakes.Data
{
  public partial class LakeDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public LakeDataContext(DbContextOptions<LakeDataContext> options):base(options)
    {
    }

    public LakeDataContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Lakes.Models.LakeData.VwPlace>().HasNoKey();

        this.OnModelBuilding(builder);
    }


    public DbSet<Lakes.Models.LakeData.VwPlace> VwPlaces
    {
      get;
      set;
    }
  }
}
