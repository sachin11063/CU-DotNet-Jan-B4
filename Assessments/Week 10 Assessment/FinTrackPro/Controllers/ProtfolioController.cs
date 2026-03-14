using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;
using System.Collections.Generic;
using System.Linq;

public class PortfolioController : Controller
{
    private static List<Asset> assets = new List<Asset>()
    {
        new Asset{ Id = 1, Name="Apple", Price=200 },
        new Asset{ Id = 2, Name="Tesla", Price=300 }
    };

    public IActionResult Index()
    {
        double total = assets.Sum(a => a.Price);
        ViewData["Total"] = total;

        return View(assets);
    }

    [Route("Asset/Info/{id:int}")]
    public IActionResult Details(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);
        return View(asset);
    }

    public IActionResult Delete(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);

        if (asset != null)
        {
            assets.Remove(asset);
            TempData["Message"] = "Asset deleted successfully";
        }

        return RedirectToAction("Index");
    }
}