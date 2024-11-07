using Microsoft.EntityFrameworkCore;
using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Data.Repositories;

public class VotingProcessRepository : Repository<VotingProcess>, IVotingProcessRepository
{
    private readonly ApplicationDbContext context;

    public VotingProcessRepository(ApplicationDbContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<VotingProcess> GetActiveVotingProcessForUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await this.context.VotingProcesses
            .FirstOrDefaultAsync(vp => vp.BirthdayPersonId == userId && vp.EndDate == null, cancellationToken);
    }
}
