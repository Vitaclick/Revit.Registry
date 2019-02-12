using System;
using System.Collections.Generic;
using System.Text;

namespace Reg.Contracts
{
  public interface IExceptionHandler
  {
    T Run<T>(Func<T> func);
  }
}
