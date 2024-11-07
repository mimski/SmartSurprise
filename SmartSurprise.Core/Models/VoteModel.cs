namespace SmartSurprise.Core.Models;

public class VoteModel
{
    public int Id { get; set; }

    public int VotingProcessId { get; set; }

    public string VoterId { get; set; }

    public string VoterName { get; set; }

    public int GiftId { get; set; }

    public string GiftName { get; set; }
}
