using SmartSurprise.Core.Models;

namespace SmartSurprise.Core.Services.Contracts;

public interface IGiftService
{
    Task<IEnumerable<GiftModel>> GetAllGiftsAsync(CancellationToken cancellationToken = default);

    Task<GiftModel> GetGiftByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddGiftAsync(GiftModel giftModel, CancellationToken cancellationToken = default);

    Task UpdateGiftAsync(GiftModel giftModel, CancellationToken cancellationToken = default);

    Task DeleteGiftAsync(int id, CancellationToken cancellationToken = default);
}
