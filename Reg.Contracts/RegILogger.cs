using System;

namespace Reg.Contracts
{
  public interface RegILogger
  {
    void Log(Exception ex);
  }
}