using Microsoft.AspNetCore.Mvc;

public class MarketController : Controller
{
    public IActionResult Summary()
    {
        ViewBag.MarketStatus = "Open";
        ViewData["TopGainer"] = "NVIDIA";
        ViewData["Volume"] = 123456789L;

        return View();
    }

    [HttpGet("Analyze/{ticker}/{days:int?}")]
    public IActionResult Analyze(string ticker, int? days)
    {
        int period = days ?? 30;

        ViewBag.Ticker = ticker;
        ViewBag.Days = period;

        return View();
    }
}