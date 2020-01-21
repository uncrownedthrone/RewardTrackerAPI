using System.Collections.Generic;

namespace RewardTrackerAPI.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string House { get; set; }
    public int PeriodId { get; set; }
    public Period Period { get; set; }
    public List<RewardRecord> RewardRecords { get; set; } = new List<RewardRecord>();
  }
}