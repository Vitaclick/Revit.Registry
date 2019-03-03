using System;

namespace Reg.Contracts
{
  public interface IRegLogger
  {
    void Log(string message);
    void Exception(Exception ex);
  }
}