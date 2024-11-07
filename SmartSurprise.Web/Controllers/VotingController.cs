using Microsoft.AspNetCore.Mvc;
using SmartSurprise.Core.Services.Contracts;
using SmartSurprise.Web.Models;
using System.Threading.Tasks;

namespace SmartSurprise.Web.Controllers;

public class VotingController : Controller
{
    private readonly IVotingService votingService;

    public VotingController(IVotingService votingService)
    {
        this.votingService = votingService;
    }

    // GET: Voting/Start
    public async Task<IActionResult> Start(string birthdayPersonId)
    {
        var giftOptions = await this.votingService.GetGiftOptionsAsync();

        ViewBag.GiftOptions = giftOptions;

        return View(new VotingProcessViewModel { BirthdayPersonId = birthdayPersonId });
    }

    // POST: Voting/Start
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Start(VotingProcessViewModel model)
    {
        if (ModelState.IsValid)
        {
            await this.votingService.StartVotingProcessAsync(model.BirthdayPersonId, User.Identity.Name);

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    // GET: Voting/Vote
    public async Task<IActionResult> Vote(int votingProcessId)
    {
        var votingProcess = await this.votingService.GetVotingProcessByIdAsync(votingProcessId);

        if (votingProcess == null || votingProcess.EndDate != null)
        {
            return NotFound();
        }

        var giftOptions = await this.votingService.GetGiftOptionsAsync();
        ViewBag.GiftOptions = giftOptions;

        return View(new VoteViewModel { VotingProcessId = votingProcessId });
    }

    // POST: Voting/Vote
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Vote(VoteViewModel model)
    {
        if (ModelState.IsValid)
        {
            await this.votingService.CastVoteAsync(model.VotingProcessId, User.Identity.Name, model.GiftId);

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    // GET: Voting/End
    public async Task<IActionResult> End(int votingProcessId)
    {
        await this.votingService.EndVotingProcessAsync(votingProcessId);

        return RedirectToAction("Index", "Home");
    }

    // GET: Voting/Results
    public async Task<IActionResult> Results(int votingProcessId)
    {
        var votingProcess = await this.votingService.GetVotingProcessByIdAsync(votingProcessId);

        if (votingProcess == null)
        {
            return NotFound();
        }

        return View(votingProcess);
    }
}
