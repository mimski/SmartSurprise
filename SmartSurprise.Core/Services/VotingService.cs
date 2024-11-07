using SmartSurprise.Core.Models;
using SmartSurprise.Core.Services.Contracts;
using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Core.Services;

public class VotingService : IVotingService
{
    private readonly IVotingProcessRepository votingProcessRepository;
    private readonly IGiftRepository giftRepository;
    private readonly IVoteRepository voteRepository;

    public VotingService(
        IVotingProcessRepository votingProcessRepository,
        IGiftRepository giftRepository,
        IVoteRepository voteRepository)
    {
        this.votingProcessRepository = votingProcessRepository;
        this.giftRepository = giftRepository;
        this.voteRepository = voteRepository;
    }

    public async Task StartVotingProcessAsync(string birthdayPersonId, string initiatorId, CancellationToken cancellationToken = default)
    {
        var existingVote = await this.votingProcessRepository.GetActiveVotingProcessForUserAsync(birthdayPersonId, cancellationToken);

        if (existingVote != null)
        {
            throw new InvalidOperationException("A voting process is already active for this user.");
        }

        var votingProcess = new VotingProcess
        {
            BirthdayPersonId = birthdayPersonId,
            InitiatorId = initiatorId,
            StartDate = DateTime.UtcNow
        };

        await this.votingProcessRepository.AddAsync(votingProcess, cancellationToken);
        await this.votingProcessRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<VotingProcessModel> GetActiveVotingProcessForUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        var votingProcess = await this.votingProcessRepository.GetActiveVotingProcessForUserAsync(userId, cancellationToken);

        if (votingProcess == null) return null;

        return new VotingProcessModel
        {
            Id = votingProcess.Id,
            BirthdayPersonId = votingProcess.BirthdayPersonId,
            BirthdayPersonName = votingProcess.BirthdayPerson.Name,
            InitiatorId = votingProcess.InitiatorId,
            InitiatorName = votingProcess.Initiator.Name,
            StartDate = votingProcess.StartDate,
            EndDate = votingProcess.EndDate,
            Votes = votingProcess.Votes.Select(v => new VoteModel
            {
                Id = v.Id,
                VoterId = v.VoterId,
                VoterName = v.Voter.Name,
                GiftId = v.GiftId,
                GiftName = v.Gift.Name
            }).ToList()
        };
    }

    public async Task<IEnumerable<GiftModel>> GetGiftOptionsAsync(CancellationToken cancellationToken = default)
    {
        var gifts = await this.giftRepository.GetAllAsync(cancellationToken);
        return gifts.Select(g => new GiftModel
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description
        });
    }

    public async Task CastVoteAsync(int votingProcessId, string voterId, int giftId, CancellationToken cancellationToken = default)
    {
        var votingProcess = await this.votingProcessRepository.GetByIdAsync(votingProcessId, cancellationToken);

        if (votingProcess == null || votingProcess.EndDate != null)
        {
            throw new InvalidOperationException("Voting process is not active or does not exist.");
        }

        var existingVote = votingProcess.Votes.FirstOrDefault(v => v.VoterId == voterId);

        if (existingVote != null)
        {
            throw new InvalidOperationException("You have already voted in this process.");
        }

        var vote = new Vote
        {
            VotingProcessId = votingProcessId,
            VoterId = voterId,
            GiftId = giftId
        };

        await this.voteRepository.AddAsync(vote, cancellationToken);
        await this.voteRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task EndVotingProcessAsync(int votingProcessId, CancellationToken cancellationToken = default)
    {
        var votingProcess = await this.votingProcessRepository.GetByIdAsync(votingProcessId, cancellationToken);

        if (votingProcess == null || votingProcess.EndDate != null)
        {
            throw new InvalidOperationException("Voting process is not active or does not exist.");
        }

        votingProcess.EndDate = DateTime.UtcNow;

        this.votingProcessRepository.Update(votingProcess);
        await this.votingProcessRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<VotingProcessModel> GetVotingProcessByIdAsync(int votingProcessId, CancellationToken cancellationToken = default)
    {
        var votingProcess = await this.votingProcessRepository.GetByIdAsync(votingProcessId, cancellationToken);

        if (votingProcess == null) return null;

        return new VotingProcessModel
        {
            Id = votingProcess.Id,
            BirthdayPersonId = votingProcess.BirthdayPersonId,
            BirthdayPersonName = votingProcess.BirthdayPerson.Name,
            InitiatorId = votingProcess.InitiatorId,
            InitiatorName = votingProcess.Initiator.Name,
            StartDate = votingProcess.StartDate,
            EndDate = votingProcess.EndDate,
            Votes = votingProcess.Votes.Select(v => new VoteModel
            {
                Id = v.Id,
                VoterId = v.VoterId,
                VoterName = v.Voter.Name,
                GiftId = v.GiftId,
                GiftName = v.Gift.Name
            }).ToList()
        };
    }
}
