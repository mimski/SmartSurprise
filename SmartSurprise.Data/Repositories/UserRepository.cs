using Microsoft.EntityFrameworkCore;
using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Data.Repositories;

public class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    private readonly ApplicationDbContext context;

    public UserRepository(ApplicationDbContext context) 
        : base(context)
    {
        this.context = context;
    }

    public async Task<ApplicationUser> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await this.context.Users
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }
}
