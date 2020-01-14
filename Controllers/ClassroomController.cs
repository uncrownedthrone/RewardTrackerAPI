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
  public class ClassroomController : ControllerBase
  {
    private readonly DatabaseContext db;

    public ClassroomController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Classroom
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
    {
      return await db.Classrooms.ToListAsync();
    }

    // GET: api/Classroom/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Classroom>> GetClassroom(int id)
    {
      var classroom = await db.Classrooms.FindAsync(id);

      if (classroom == null)
      {
        return NotFound();
      }

      return classroom;
    }

    // PUT: api/Classroom/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
    {
      if (id != classroom.Id)
      {
        return BadRequest();
      }

      db.Entry(classroom).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ClassroomExists(id))
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

    // POST: api/Classroom
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
    {
      db.Classrooms.Add(classroom);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetClassroom", new { id = classroom.Id }, classroom);
    }

    // DELETE: api/Classroom/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Classroom>> DeleteClassroom(int id)
    {
      var classroom = await db.Classrooms.FindAsync(id);
      if (classroom == null)
      {
        return NotFound();
      }

      db.Classrooms.Remove(classroom);
      await db.SaveChangesAsync();

      return classroom;
    }

    private bool ClassroomExists(int id)
    {
      return db.Classrooms.Any(e => e.Id == id);
    }
  }
}
