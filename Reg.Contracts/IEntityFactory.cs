using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reg.Domain.Entities;

namespace Reg.Contracts
{
  public interface IEntityFactory<T> where T: BaseEntity
  {
    Task<bool> CreateAsync(T entity);
    Task<T> GetAsync(int id);
    Task<bool> RemoveAsync(int id);
    Task<ICollection<T>> GetAllAsync();
  }
}
