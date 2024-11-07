using SmartSurprise.Core.Models;
using SmartSurprise.Core.Services.Contracts;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Core.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository voteRepository;

    public VoteService(IVoteRepository voteRepository)
    {
        this.voteRepository = voteRepository;
    }

    public async Task<VoteModel> GetVoteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var vote = await this.voteRepository.GetByIdAsync(id, cancellationToken);

        if (vote == null) return null;

        return new VoteModel
        {
            Id = vote.Id,
            VotingProcessId = vote.VotingProcessId,
            VoterId = vote.VoterId,
            VoterName = vote.Voter.Name,
            GiftId = vote.GiftId,
            GiftName = vote.Gift.Name
        };
    }

    public async Task<VoteModel> GetVoteByVoterAndProcessAsync(string voterId, int votingProcessId, CancellationToken cancellationToken = default)
    {
        var vote = await this.voteRepository.GetVoteByVoterAndProcessAsync(voterId, votingProcessId, cancellationToken);
        if (vote == null) return null;

        return new VoteModel
        {
            Id = vote.Id,
            VotingProcessId = vote.VotingProcessId,
            VoterId = vote.VoterId,
            VoterName = vote.Voter.Name,
            GiftId = vote.GiftId,
            GiftName = vote.Gift.Name
        };
    }
}
