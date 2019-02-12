using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;
using Reg.Logic.Factories;
using Reg.Logic.Handlers;
using Reg.Logic.Managers;
using Reg.Logic.Validators;

namespace Revit.Registry
{
  class Program
  {
    public IServiceProvider Services { get; private set; }

    static void Main(string[] args)
    {
      var configurationBuilder = new ConfigurationBuilder();
      var configRoot = configurationBuilder.Build();

      var services = new ServiceCollection();

      services.AddDbContext<RegDbContext>();
      services.AddTransient<ILogger, Logger>();
      services.AddTransient<IValidator<Project>, ProjectValidator>();
      services.AddTransient<IExceptionHandler, ExceptionHandler>();
      services.AddTransient<IEntityFactory<Project>, ProjectFactory>();
      services.AddTransient<IProjectRepository, ProjectManager>();


      var revitData = new List<IList<object>>() { new List<object>() { "lol", "kek", "cheburek" } };

//      var data = new List<object>(){"lol", "kek", "cheburek"};

//      foreach (var i in data)
//      {
//        revitData.Add((IList<object>)i);
//      }

      var transfer = new Transfer();
      transfer.WriteData("A:A", revitData);

      Console.WriteLine("Hello World!");

    }
  }
}
