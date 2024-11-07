using SmartSurprise.Core.Models;

namespace SmartSurprise.Core.Services.Contracts;

public interface IVotingService
{
    Task StartVotingProcessAsync(string birthdayPersonId, string initiatorId, CancellationToken cancellationToken = default);

    Task<VotingProcessModel> GetActiveVotingProcessForUserAsync(string userId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GiftModel>> GetGiftOptionsAsync(CancellationToken cancellationToken = default);

    Task CastVoteAsync(int votingProcessId, string voterId, int giftId, CancellationToken cancellationToken = default);

    Task EndVotingProcessAsync(int votingProcessId, CancellationToken cancellationToken = default);

    Task<VotingProcessModel> GetVotingProcessByIdAsync(int votingProcessId, CancellationToken cancellationToken = default);
}
