using SmartSurprise.Data.Entities;

namespace SmartSurprise.Data.Repositories.Contracts;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
}
