using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardTrackerAPI.Models;

namespace RewardTrackerAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeacherController : ControllerBase
  {
    private readonly DatabaseContext db;

    public TeacherController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Teacher
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
    {
      return await db.Teachers.ToListAsync();
    }

    // GET: api/Teacher/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
      var teacher = await db.Teachers.FindAsync(id);

      if (teacher == null)
      {
        return NotFound();
      }

      return teacher;
    }

    // PUT: api/Teacher/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
    {
      if (id != teacher.Id)
      {
        return BadRequest();
      }

      db.Entry(teacher).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TeacherExists(id))
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

    // POST: api/Teacher
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
    {
      db.Teachers.Add(teacher);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
    }

    // DELETE: api/Teacher/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
    {
      var teacher = await db.Teachers.FindAsync(id);
      if (teacher == null)
      {
        return NotFound();
      }

      db.Teachers.Remove(teacher);
      await db.SaveChangesAsync();

      return teacher;
    }

    private bool TeacherExists(int id)
    {
      return db.Teachers.Any(e => e.Id == id);
    }
  }
}
