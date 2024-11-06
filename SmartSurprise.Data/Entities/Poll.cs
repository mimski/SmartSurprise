namespace SmartSurprise.Data.Entities;

public class Poll
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public User User { get; set; }
    public ICollection<Vote> Votes { get; set; }
}