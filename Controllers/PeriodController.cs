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
  public class PeriodController : ControllerBase
  {
    private readonly DatabaseContext db;

    public PeriodController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Classroom
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Period>>> GetPeriod()
    {
      return await db.Periods.ToListAsync();
    }

    // GET: api/Classroom/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Period>> GetClassroom(int id)
    {
      var period = await db.Periods.FindAsync(id);

      if (period == null)
      {
        return NotFound();
      }

      return period;
    }

    [HttpGet("AllStudentsJoin/{Id}")]
    public ActionResult<IEnumerable<Object>> GetPeriodStudents(int Id)
    {
      var students = db.Students.Where(w => w.PeriodId == Id);
      return students.ToList();
    }

    // PUT: api/Classroom/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeriod(int id, Period period)
    {
      if (id != period.Id)
      {
        return BadRequest();
      }

      db.Entry(period).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PeriodExists(id))
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
    public async Task<ActionResult<Period>> PostPeriod(Period period)
    {
      db.Periods.Add(period);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetPeriod", new { id = period.Id }, period);
    }

    // DELETE: api/Classroom/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Period>> DeletePeriod(int id)
    {
      var period = await db.Periods.FindAsync(id);
      if (period == null)
      {
        return NotFound();
      }

      db.Periods.Remove(period);
      await db.SaveChangesAsync();

      return period;
    }

    private bool PeriodExists(int id)
    {
      return db.Periods.Any(e => e.Id == id);
    }
  }
}
