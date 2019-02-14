using System;
using System.Collections.Generic;
using System.Text;
using Reg.Contracts;

namespace Reg.Logic.Handlers
{
  public class ExceptionHandler: IExceptionHandler
  {
    private RegILogger _logger;

    public ExceptionHandler(RegILogger logger)
    {
      _logger = logger;
    }
    public T Run<T>(Func<T> func)
    {
      try
      {
        return func.Invoke();
      }
      catch (Exception ex)
      {
        _logger.Log(ex);
      }
      return default(T);

    }
  }
}
