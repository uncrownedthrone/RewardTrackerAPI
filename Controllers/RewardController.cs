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
  public class RewardController : ControllerBase
  {
    private readonly DatabaseContext db;

    public RewardController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Reward
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reward>>> GetRewards()
    {
      return await db.Rewards.ToListAsync();
    }

    // GET: api/Reward/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Reward>> GetReward(int id)
    {
      var reward = await db.Rewards.FindAsync(id);

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
    public async Task<IActionResult> PutReward(int id, Reward reward)
    {
      if (id != reward.Id)
      {
        return BadRequest();
      }

      db.Entry(reward).State = EntityState.Modified;

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
    public async Task<ActionResult<Reward>> PostReward(Reward reward)
    {
      db.Rewards.Add(reward);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetReward", new { id = reward.Id }, reward);
    }

    // DELETE: api/Reward/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Reward>> DeleteReward(int id)
    {
      var reward = await db.Rewards.FindAsync(id);
      if (reward == null)
      {
        return NotFound();
      }

      db.Rewards.Remove(reward);
      await db.SaveChangesAsync();

      return reward;
    }

    private bool RewardExists(int id)
    {
      return db.Rewards.Any(e => e.Id == id);
    }
  }
}
