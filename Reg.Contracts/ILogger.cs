using System;

namespace Reg.Contracts
{
  public interface ILogger
  {
    void Log(Exception ex);
  }
}