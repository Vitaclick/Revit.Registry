using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;

namespace Reg.Logic.Factories
{
  public class ProjectFactory: IEntityFactory<Project>
  {
    private RegDbContext _context;

    public ProjectFactory(RegDbContext context)
    {
      _context = context;
    }

    public async Task<bool> CreateAsync(Project entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof(entity));
      return await Task<bool>.Factory.StartNew(() =>
      {
        _context.Projects.AddAsync(entity);
        _context.SaveChangesAsync();
        return true;
      });
    } 

    public Task<Project> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<ICollection<Project>> GetAllAsync()
    {
      if (!await _context.Projects.AnyAsync())
        return null;
      return await _context.Projects.ToListAsync();
    }
  }
}
