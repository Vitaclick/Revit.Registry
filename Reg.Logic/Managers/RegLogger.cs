using System;
using System.Text;
using Reg.Contracts;

namespace Reg.Logic.Managers
{
  public class RegLogger : IRegLogger
  {
    public void Exception(Exception ex)
    {
      throw new NotImplementedException();
    }

    public void Log(string message)
    {

    }

  }
}
