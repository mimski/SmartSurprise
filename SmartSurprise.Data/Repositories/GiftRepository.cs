using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Data.Repositories;

public class GiftRepository : Repository<Gift>, IGiftRepository
{
    private readonly ApplicationDbContext context;

    public GiftRepository(ApplicationDbContext context) 
        : base(context)
    {
        this.context = context;
    }
}
