namespace SmartSurprise.Core.Models;

public class VotingProcessModel
{
    public int Id { get; set; }

    public string BirthdayPersonId { get; set; }

    public string BirthdayPersonName { get; set; }

    public string InitiatorId { get; set; }

    public string InitiatorName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public ICollection<VoteModel> Votes { get; set; } = [];
}
