using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reg.Contracts;
using Reg.Domain.Entities;

namespace Reg.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModelsController : ControllerBase
  {
    private readonly IProjectRepository repository;
    private readonly IRegLogger regLogger;

    public ModelsController(IProjectRepository repository, IRegLogger regLogger)
    {
      this.repository = repository;
      this.regLogger = regLogger;
    }

    [HttpGet]
    [Route("GetProjectFiles")]
    public ActionResult<List<Model>> GetProjectFiles(string projectName)
    {
      var models = repository.GetProjectFiles(projectName).Result;

      if (models.Count == 0)
      {
        return NotFound();
      }

      return models.ToList();
    }

    [HttpGet]
    [Route("GetModelLog")]
    public ActionResult<List<Log>> GetModelLog(string modelName)
    {
      return repository.GetModelLogs(modelName).Result.ToList();
    }

    public ActionResult LogData(string message)
    {
      if (message == null)
      {
        return NoContent();
      }
      regLogger.Log(message);
      return Ok();
    }
  }
}