using Microsoft.AspNetCore.Mvc;
using SmartSurprise.Core.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace SmartSurprise.Web.Controllers;

public class VoteController : Controller
{
    private readonly IVoteService voteService;

    public VoteController(IVoteService voteService)
    {
        this.voteService = voteService;
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var vote = await this.voteService.GetVoteByIdAsync(id, cancellationToken);
        if (vote == null) return NotFound();

        return View(vote);
    }

    [HttpGet]
    public async Task<IActionResult> HasUserVoted(string userId, int votingProcessId, CancellationToken cancellationToken)
    {
        var vote = await this.voteService.GetVoteByVoterAndProcessAsync(userId, votingProcessId, cancellationToken);

        if (vote == null) return Json(new { hasVoted = false });

        return Json(new { hasVoted = true, vote });
    }
}
