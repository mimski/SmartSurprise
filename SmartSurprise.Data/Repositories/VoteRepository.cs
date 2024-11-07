using Microsoft.EntityFrameworkCore;
using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Data.Repositories;

public class VoteRepository : Repository<Vote>, IVoteRepository
{
    private readonly ApplicationDbContext context;

    public VoteRepository(ApplicationDbContext context) 
        : base(context)
    {
        this.context = context;
    }

    public async Task<Vote> GetVoteByVoterAndProcessAsync(string voterId, int votingProcessId, CancellationToken cancellationToken = default)
    {
        return await this.context.Votes
            .FirstOrDefaultAsync(vote => vote.VoterId == voterId && vote.VotingProcessId == votingProcessId, cancellationToken);
    }
}
