using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reg.DataAccess.Contexts;
using Xunit;

namespace Reg.Test
{
  public class BasicCRUD
  {
    [Fact]
    public async Task BasicCrud()
    {
      // setup test database
      var options = new DbContextOptionsBuilder<RegDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDbBasic").Options;
      // set up context
      using (var context = new RegDbContext(options))
      {
//        var service new 
      }

    }
  }
}
