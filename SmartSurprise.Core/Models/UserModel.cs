namespace SmartSurprise.Core.Models;

public class UserModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<VotingProcessModel> InitiatedVotingProcesses { get; set; }

    public ICollection<VotingProcessModel> BirthdayVotingProcesses { get; set; }

    public ICollection<VoteModel> Votes { get; set; }
}
