using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;
using Reg.Logic.Factories;
using Reg.Logic.Handlers;
using Reg.Logic.Managers;
using Reg.Logic.Validators;

namespace Revit.Registry
{
//  public class ParseRSN : IHostedService, IDisposable
//  {
//    private readonly ILogger _logger;
////    private readonly IOptions<>
//  }
  class Program
  {
//    public IServiceProvider Services { get; private set; }

    static async Task Main(string[] args)
    {
      var host = new HostBuilder()
        .ConfigureHostConfiguration(configBuidler =>
        {
          configBuidler.AddJsonFile("appsettings.json", optional: true);
          configBuidler.AddCommandLine(args);
        })

        //is used to register services (“dependencies”) with the service (“dependency injection”) container.
        .ConfigureServices((hostContent, services) =>
        {
          services.AddDbContext<RegDbContext>();
          services.AddTransient<ILogger, Logger>();
          services.AddTransient<IValidator<Project>, ProjectValidator>();
          services.AddTransient<IExceptionHandler, ExceptionHandler>();
          services.AddTransient<IEntityFactory<Project>, ProjectFactory>();
          services.AddTransient<IProjectRepository, ProjectManager>();
        })
//        .ConfigureLogging((hostContext, configLogging) => { configLogging.AddConsole(); })
        .UseConsoleLifetime()
        .Build();

      // console
//      await host.RunConsoleAsync();
      await host.RunAsync();




//
//      var configurationBuilder = new ConfigurationBuilder();
//      var configRoot = configurationBuilder.Build();

//      var services = new ServiceCollection();




      

      var revitData = new List<IList<object>>() { new List<object>() { "lol", "kek", "cheburek" } };

//      var data = new List<object>(){"lol", "kek", "cheburek"};

//      foreach (var i in data)
//      {
//        revitData.Add((IList<object>)i);
//      }

//      var transfer = new Transfer();
//      transfer.WriteData("A:A", revitData);

      Console.WriteLine("Hello World!");

    }
  }
}
