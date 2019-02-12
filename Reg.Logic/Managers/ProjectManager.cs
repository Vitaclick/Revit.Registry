using System;
using System.Collections.Generic;
using Reg.Contracts;
using Reg.Domain.Entities;

namespace Reg.Logic.Managers
{
  public class ProjectManager : IProjectRepository
  {
    private IEntityFactory<Project> _factory;
    private IValidator<Project> _validator;
    private IExceptionHandler _handler;

    public ProjectManager(IExceptionHandler handler, IValidator<Project> validator, IEntityFactory<Project> factory)
    {
      _handler = handler;
      _validator = validator;
      _factory = factory;
    }

    public bool AddProject(Project project)
    {
      if (_validator.IsValid(project))
        return _handler.Run(() => _factory.CreateAsync(project).Result);
      return false;
    }

    public Project GetProject(int id)
    {
      throw new NotImplementedException();
    }

    public bool RemoveProject(int id)
    {
      throw new NotImplementedException();
    }

    public ICollection<Project> GetAllProjects()
    {
      return _handler.Run(() => _factory.GetAllAsync().Result);
    }
  }
}
