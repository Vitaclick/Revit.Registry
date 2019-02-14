using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;
using Reg.Logic.Factories;
using Reg.Logic.Handlers;
using Reg.Logic.Managers;
using Reg.Logic.Validators;

namespace Reg.Logic
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      var host = new HostBuilder()
        .ConfigureHostConfiguration(configHost =>
        {
          configHost.SetBasePath(Directory.GetCurrentDirectory());
          configHost.AddJsonFile("hostsettings.json", optional: true);
          configHost.AddJsonFile("appsettings.json", optional: true);
          configHost.AddCommandLine(args);
        })
        .ConfigureAppConfiguration(((hostContext, configApp) =>
        {
          configApp.AddJsonFile("appsettings.json", optional: true);
          configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
            optional: true);
          configApp.AddCommandLine(args);
        }))

        //is used to register services (“dependencies”) with the service (“dependency injection”) container.
        .ConfigureServices((hostContent, services) =>
        {
          services.Configure<AppSettings>()

          services.AddHostedService<CrawlerRsnService>();
          services.AddDbContext<RegDbContext>();
          services.AddTransient<RegILogger, RegLogger>();
          services.AddTransient<IValidator<Project>, ProjectValidator>();
          services.AddTransient<IExceptionHandler, ExceptionHandler>();
          services.AddTransient<IEntityFactory<Project>, ProjectFactory>();
          services.AddTransient<IProjectRepository, ProjectManager>();
        })
        .ConfigureLogging((hostContext, configLogging) =>
        {
          configLogging.AddConsole();
        })
        .UseConsoleLifetime()
        .Build();

//      await host.RunConsoleAsync();
      await host.RunAsync();

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
