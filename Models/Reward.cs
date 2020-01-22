using System.Text.Json.Serialization;

namespace RewardTrackerAPI.Models
{
  public class RewardRecord
  {
    public int Id { get; set; }
    public string Reason { get; set; }
    public int RewardAmount { get; set; }
    public int StudentId { get; set; }
    [JsonIgnore]

    public Student Student { get; set; }
    public int TeacherId { get; set; }
    [JsonIgnore]
    public Teacher Teacher { get; set; }
  }
}