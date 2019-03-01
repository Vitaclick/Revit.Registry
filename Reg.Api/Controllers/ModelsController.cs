using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
      private readonly IProjectRepository _repository;

      public ModelsController(IProjectRepository repository)
      {
        _repository = repository;
      }

      [HttpGet]
      [Route("GetProjectFiles")]
      public ActionResult<List<Model>> GetProjectFiles(Project project)
      {
        var models = _repository.GetProjectFiles(project).Result;

        if (models.Count == 0)
        {
          return NotFound();
        }

        return models.ToList();
      }
    }
}