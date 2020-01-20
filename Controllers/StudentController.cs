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
  public class StudentController : ControllerBase
  {
    private readonly DatabaseContext db;

    public StudentController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
      return await db.Students.ToListAsync();
    }

    // GET: api/Student/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
      var student = await db.Students.FindAsync(id);

      if (student == null)
      {
        return NotFound();
      }

      return student;
    }

    // PUT: api/Student/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
      if (id != student.Id)
      {
        return BadRequest();
      }

      db.Entry(student).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StudentExists(id))
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

    [HttpGet("AllRewards/{Id}")]
    public ActionResult<IEnumerable<Object>> GetRewards(int Id)
    {
      var rewards = db.Rewards.Where(w => w.StudentId == Id);
      return rewards.ToList();
    }

    // POST: api/Student
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
      db.Students.Add(student);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // DELETE: api/Student/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
      var student = await db.Students.FindAsync(id);
      if (student == null)
      {
        return NotFound();
      }

      db.Students.Remove(student);
      await db.SaveChangesAsync();

      return student;
    }

    private bool StudentExists(int id)
    {
      return db.Students.Any(e => e.Id == id);
    }
  }
}
