using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;

namespace Reg.Logic.Managers
{
  public class ProjectManager : IProjectRepository
  {
//    private IEntityFactory<Project> _factory;
//    private IValidator<Project> _validator;
    private readonly RegDbContext _context;
//    private IExceptionHandler _handler;

    public ProjectManager(RegDbContext context
//      , IExceptionHandler handler, IValidator<Project> validator, IEntityFactory<Project> factory
      )
    {
      _context = context;
//      _handler = handler;
//      _validator = validator;
//      _factory = factory;
    }

//    public async Task<bool> AddProject(Project project)
//    {
//      if (_validator.IsValid(project))
//        return await _handler.Run(() => _factory.CreateAsync(project));
//      return false;
//    }
//
//    public Task<Project> GetProject(int id)
//    {
//      throw new NotImplementedException();
//    }
//
//    public Task<bool> RemoveProject(int id)
//    {
//      throw new NotImplementedException();
//    }
//
//    public Task<ICollection<Project>> GetAllProjects()
//    {
//      return _handler.Run(() => _factory.GetAllAsync());
//    }

    public async Task<ICollection<Model>> GetProjectFiles(Project project)
    {
      if (!await _context.Projects.AnyAsync())
        return null;
      var projects = await _context.Projects.ToListAsync();
      foreach (var prj in projects)
      {
        if (prj.Name == project.Name)
        {
          return prj.Models;
        }
      }
      return null;
    }
  }
}
