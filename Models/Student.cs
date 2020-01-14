namespace RewardTrackerAPI.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string House { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
  }
}