using Microsoft.Extensions.DependencyInjection;
using SmartSurprise.Core.Services;
using SmartSurprise.Core.Services.Contracts;
using SmartSurprise.Data.Repositories;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Web.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Register Services
        services.AddScoped<IGiftService, GiftService>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<IVotingService, VotingService>();

        // Register Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGiftRepository, GiftRepository>();
        services.AddScoped<IVoteRepository, VoteRepository>();
        services.AddScoped<IVotingProcessRepository, VotingProcessRepository>();

        // Register the Generic Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
