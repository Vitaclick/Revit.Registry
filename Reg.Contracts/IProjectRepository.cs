﻿using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reg.Domain.Entities;

namespace Reg.Contracts
{
  public interface IProjectRepository
  {
    //    Task<bool> AddProject(Project project);
    //    Task<Project> GetProject(int id);
    //    Task<bool> RemoveProject(int id);
    //    Task<ICollection<Project>> GetAllProjects();
    Task<ICollection<Model>> GetProjectFiles(string projectName);
    Task<ICollection<Log>> GetModelLogs(string modelName);
  }
}
