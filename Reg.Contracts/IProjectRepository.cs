using System.Collections.Generic;
using System.Text;
using Reg.Domain.Entities;

namespace Reg.Contracts
{
  public interface IProjectRepository
  {
    bool AddProject(Project project);
    Project GetProject(int id);
    bool RemoveProject(int id);
    ICollection<Project> GetAllProjects();
  }
}
