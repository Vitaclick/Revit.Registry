using System;

namespace Reg.Contracts
{
  public interface IValidator<T>
  {
    bool IsValid(T entity);
  }
}
