using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardTrackerAPI.Models;
using RewardTrackerAPI.ViewModels;

namespace RewardTrackerAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RewardController : ControllerBase
  {
    private readonly DatabaseContext db;

    public RewardController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Reward
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RewardRecord>>> GetRewards()
    {
      return await db.RewardRecords.ToListAsync();
    }

    // GET: api/RewardRecord/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RewardRecord>> GetReward(int id)
    {
      var reward = await db.RewardRecords.FindAsync(id);

      if (reward == null)
      {
        return NotFound();
      }

      return reward;
    }

    // PUT: api/Reward/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReward(int id, RewardRecord rewardRecord)
    {
      if (id != rewardRecord.Id)
      {
        return BadRequest();
      }

      db.Entry(rewardRecord).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RewardExists(id))
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

    // POST: api/Reward
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<RewardRecord>> CreateReward(RewardDetails vm)
    {
      var student = await db.Students.FirstOrDefaultAsync(st => st.Id == vm.StudentId);
      var teacher = await db.Teachers.FirstAsync();
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        var reward = new RewardRecord
        {
          Reason = vm.Reason,
          RewardAmount = vm.RewardAmount,
          StudentId = vm.StudentId,
          TeacherId = teacher.Id
        };
        Console.WriteLine($"---{reward.TeacherId}");
        db.RewardRecords.Add(reward);
        await db.SaveChangesAsync();
        var rv = new RewardRecord
        {
          Id = reward.Id,
          Reason = reward.Reason,
          RewardAmount = reward.RewardAmount,
          StudentId = reward.StudentId
        };
        return Ok(reward);
      }
    }

    // DELETE: api/Reward/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<RewardRecord>> DeleteReward(int id)
    {
      var reward = await db.RewardRecords.FindAsync(id);
      if (reward == null)
      {
        return NotFound();
      }

      db.RewardRecords.Remove(reward);
      await db.SaveChangesAsync();

      return reward;
    }

    private bool RewardExists(int id)
    {
      return db.RewardRecords.Any(e => e.Id == id);
    }
  }
}
