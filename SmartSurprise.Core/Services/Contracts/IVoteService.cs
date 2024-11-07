using SmartSurprise.Core.Models;

namespace SmartSurprise.Core.Services.Contracts;

public interface IVoteService
{
    Task<VoteModel> GetVoteByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<VoteModel> GetVoteByVoterAndProcessAsync(string voterId, int votingProcessId, CancellationToken cancellationToken = default);
}
