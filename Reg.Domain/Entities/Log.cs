using System;
using System.Collections.Generic;
using System.Text;

namespace Reg.Domain.Entities
{
  public class Log : BaseEntity
  {
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
  }
}
