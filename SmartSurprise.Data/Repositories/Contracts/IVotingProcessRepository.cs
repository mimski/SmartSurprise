using SmartSurprise.Data.Entities;

namespace SmartSurprise.Data.Repositories.Contracts;

public interface IVotingProcessRepository : IRepository<VotingProcess>
{
    Task<VotingProcess> GetActiveVotingProcessForUserAsync(string userId, CancellationToken cancellationToken = default);
}