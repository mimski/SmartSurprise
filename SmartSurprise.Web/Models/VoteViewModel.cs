namespace SmartSurprise.Web.Models;

public class VoteViewModel
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int GiftId { get; set; }

    public int PollId { get; set; }

    public DateTime VoteDate { get; set; }

    public UserViewModel User { get; set; }

    public GiftViewModel Gift { get; set; }

    public PollViewModel Poll { get; set; }
}
