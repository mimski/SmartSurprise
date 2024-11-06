namespace SmartSurprise.Data.Entities;

public class Vote
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GiftId { get; set; }
    public int PollId { get; set; }
    public DateTime VoteDate { get; set; }

    public User User { get; set; }
    public Gift Gift { get; set; }
    public Poll Poll { get; set; }
}
