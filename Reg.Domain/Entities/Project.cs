using System;
using System.Collections.Generic;
using System.Text;

namespace Reg.Domain.Entities
{
  public class Project: BaseEntity
  {
    public string Name { get; set; }
    public double StandartVersion { get; set; }
  }
}
