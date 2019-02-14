using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reg.Contracts;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Reg.Logic
{
  internal class CrawlerRsnService : IHostedService, IDisposable
  {
    private readonly ILogger _logger;
    private readonly IProjectRepository _projectRepository;

    public CrawlerRsnService(ILogger<CrawlerRsnService> logger, IProjectRepository projectRepository)
    {
      _logger = logger;
      _projectRepository = projectRepository;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("Crawling is started");
      CrawlRsn();
      return Task.CompletedTask;
    }

    private void CrawlRsn()
    {
      _logger.LogInformation("RSN crawling is working...");
      var projects = _projectRepository.GetAllProjects();
      foreach (var project in projects)
      {
      _logger.LogInformation(project.Name);

      }
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("RSN crawler is stopping");
      return Task.CompletedTask;
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
