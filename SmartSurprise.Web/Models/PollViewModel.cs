namespace SmartSurprise.Web.Models;

public class PollViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public UserViewModel User { get; set; }
    public ICollection<VoteViewModel> Votes { get; set; }
}
