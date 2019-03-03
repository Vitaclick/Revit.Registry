using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reg.Domain.Entities
{
  public class Model : BaseEntity
  {
    public string Name { get; set; }
    public string FullPath { get; set; }
    public Project Project { get; set; }
    public ICollection<Log> Logs { get; set; }
  }
}
