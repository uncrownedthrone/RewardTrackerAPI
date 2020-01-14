using System.Collections.Generic;

namespace RewardTrackerAPI.Models
{
  public class Classroom
  {
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
  }
}