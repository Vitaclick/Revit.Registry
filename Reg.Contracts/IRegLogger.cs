using System;

namespace Reg.Contracts
{
  public interface IRegLogger
  {
    void Log(Exception ex);
  }
}