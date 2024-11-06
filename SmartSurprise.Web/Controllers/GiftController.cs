using Microsoft.AspNetCore.Mvc;

namespace SmartSurprise.Web.Controllers;

public class GiftController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
