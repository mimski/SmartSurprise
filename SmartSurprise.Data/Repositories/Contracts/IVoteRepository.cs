using SmartSurprise.Data.Entities;

namespace SmartSurprise.Data.Repositories.Contracts;

public interface IVoteRepository : IRepository<Vote>
{
    Task<Vote> GetVoteByVoterAndProcessAsync(string voterId, int votingProcessId, CancellationToken cancellationToken = default);
}
