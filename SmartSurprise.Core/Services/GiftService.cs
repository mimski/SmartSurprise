using SmartSurprise.Core.Models;
using SmartSurprise.Core.Services.Contracts;
using SmartSurprise.Data.Entities;
using SmartSurprise.Data.Repositories.Contracts;

namespace SmartSurprise.Core.Services;

public class GiftService : IGiftService
{
    private readonly IGiftRepository giftRepository;

    public GiftService(IGiftRepository giftRepository)
    {
        this.giftRepository = giftRepository;
    }

    public async Task<IEnumerable<GiftModel>> GetAllGiftsAsync(CancellationToken cancellationToken = default)
    {
        var gifts = await this.giftRepository.GetAllAsync(cancellationToken);

        return gifts.Select(g => new GiftModel
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description
        });
    }

    public async Task<GiftModel> GetGiftByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var gift = await this.giftRepository.GetByIdAsync(id, cancellationToken);

        if (gift == null) return null;

        return new GiftModel
        {
            Id = gift.Id,
            Name = gift.Name,
            Description = gift.Description
        };
    }

    public async Task AddGiftAsync(GiftModel giftModel, CancellationToken cancellationToken = default)
    {
        var gift = new Gift
        {
            Name = giftModel.Name,
            Description = giftModel.Description
        };

        await this.giftRepository.AddAsync(gift, cancellationToken);
        await this.giftRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateGiftAsync(GiftModel giftModel, CancellationToken cancellationToken = default)
    {
        var gift = await this.giftRepository.GetByIdAsync(giftModel.Id, cancellationToken);
        if (gift == null) return;

        gift.Name = giftModel.Name;
        gift.Description = giftModel.Description;

        this.giftRepository.Update(gift);
        await this.giftRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteGiftAsync(int id, CancellationToken cancellationToken = default)
    {
        var gift = await this.giftRepository.GetByIdAsync(id, cancellationToken);
        if (gift == null) return;

        this.giftRepository.Delete(gift);
        await this.giftRepository.SaveChangesAsync(cancellationToken);
    }
}
