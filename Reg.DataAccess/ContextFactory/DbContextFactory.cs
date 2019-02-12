using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reg.DataAccess.Contexts;

namespace Reg.DataAccess.ContextFactory
{
  public class DbContextFactory: IDesignTimeDbContextFactory<RegDbContext>
  {
    public RegDbContext CreateDbContext(string[] args)
    {
      var builder = new DbContextOptionsBuilder<RegDbContext>();
      var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegTest;Integrated Security=True;Pooling=False";
      builder.UseSqlServer(connection,
        builderOption => builderOption.MigrationsAssembly(typeof(RegDbContext).GetTypeInfo().Assembly.GetName().Name));
      return new RegDbContext(builder.Options);
    }
  }
}
