using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reg.Contracts;
using Reg.DataAccess.Contexts;
using Reg.Domain.Entities;

namespace Reg.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController : ControllerBase
  {
    private readonly IProjectRepository _repository;
    private readonly RegDbContext _context;

    public ProjectsController(RegDbContext context, IProjectRepository repository)
    {
      _context = context;
      _repository = repository;
    }

    // GET: api/Projects
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,StandartVersion")] Project project)
    {
      if (ModelState.IsValid)
      {
        if (await Task<bool>.Factory.StartNew(() => _repository.AddProject(project)))
        {
          return RedirectToAction(nameof(Index));
        }
      }

      return ;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
      return await _context.Projects.ToListAsync();
    }

    // GET: api/Projects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
      var project = await _context.Projects.FindAsync(id);

      if (project == null)
      {
        return NotFound();
      }

      return project;
    }

    // PUT: api/Projects/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProject(int id, Project project)
    {
      if (id != project.Id)
      {
        return BadRequest();
      }

      _context.Entry(project).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProjectExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<ActionResult<Project>> PostProject(Project project)
    {
      _context.Projects.Add(project);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetProject", new { id = project.Id }, project);
    }

    // DELETE: api/Projects/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Project>> DeleteProject(int id)
    {
      var project = await _context.Projects.FindAsync(id);
      if (project == null)
      {
        return NotFound();
      }

      _context.Projects.Remove(project);
      await _context.SaveChangesAsync();

      return project;
    }

    private bool ProjectExists(int id)
    {
      return _context.Projects.Any(e => e.Id == id);
    }
  }
}
