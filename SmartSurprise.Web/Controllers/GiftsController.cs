using Microsoft.AspNetCore.Mvc;
using SmartSurprise.Core.Models;
using SmartSurprise.Core.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace SmartSurprise.Web.Controllers;

public class GiftsController : Controller
{
    private readonly IGiftService giftService;

    public GiftsController(IGiftService giftService)
    {
        this.giftService = giftService;
    }

    // GET: Gifts
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var gifts = await this.giftService.GetAllGiftsAsync(cancellationToken);
        return View(gifts);
    }

    // GET: Gifts/Details/5
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var gift = await this.giftService.GetGiftByIdAsync(id, cancellationToken);
        if (gift == null)
        {
            return NotFound();
        }

        return View(gift);
    }

    // GET: Gifts/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Gifts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GiftModel giftModel, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await this.giftService.AddGiftAsync(giftModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return View(giftModel);
    }

    // GET: Gifts/Edit/5
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var gift = await this.giftService.GetGiftByIdAsync(id, cancellationToken);
        if (gift == null)
        {
            return NotFound();
        }

        return View(gift);
    }

    // POST: Gifts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GiftModel giftModel, CancellationToken cancellationToken)
    {
        if (id != giftModel.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await this.giftService.UpdateGiftAsync(giftModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return View(giftModel);
    }

    // GET: Gifts/Delete/5
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var gift = await this.giftService.GetGiftByIdAsync(id, cancellationToken);
        if (gift == null)
        {
            return NotFound();
        }

        return View(gift);
    }

    // POST: Gifts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
    {
        await this.giftService.DeleteGiftAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
