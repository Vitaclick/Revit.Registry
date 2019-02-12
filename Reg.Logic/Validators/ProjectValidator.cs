using System;
using System.Collections.Generic;
using System.Text;
using Reg.Contracts;
using Reg.Domain.Entities;

namespace Reg.Logic.Validators
{
  public class ProjectValidator: IValidator<Project>
  {
    public bool IsValid(Project project)
    {
      return (!string.IsNullOrEmpty(project.Name));
    }
  }
}
