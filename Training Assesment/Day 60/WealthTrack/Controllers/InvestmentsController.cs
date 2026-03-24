using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WealthTrack.Models;

public class InvestmentsController : Controller
{
    private readonly PortfolioContext _context;

    public InvestmentsController(PortfolioContext context) 
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var investments = await _context.Investments.ToListAsync();
        return View(investments);
    }    
    
    public IActionResult Create()
    {
        return View();
    }

public IActionResult Edit(int id)
{
    var investment = _context.Investments.Find(id);
    if (investment == null)
        return NotFound();

    return View(investment);
}

// POST: Investments/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Investment investment)
{
    if (id != investment.Id)
        return NotFound();

    if (ModelState.IsValid)
    {
        _context.Update(investment);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    return View(investment);
}

// GET: Investments/Delete/5
public IActionResult Delete(int id)
{
    var investment = _context.Investments.Find(id);
    if (investment == null)
        return NotFound();

    return View(investment);
}

// POST: Investments/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var investment = _context.Investments.Find(id);
    if (investment != null)
    {
        _context.Investments.Remove(investment);
        _context.SaveChanges();
    }

    return RedirectToAction(nameof(Index));
}

public IActionResult Details(int id)
{
    var investment = _context.Investments.Find(id);

    if (investment == null)
    {
        return NotFound();
    }

    return View(investment);
}

    [HttpPost]
    public async Task<IActionResult> Create(InvestmentCreateViewModel vm)
    {
        if (ModelState.IsValid)
        {
            var model = new Investment
            {
                TickerSymbol = vm.TickerSymbol,
                AssetName = vm.AssetName,
                PurchasePrice = vm.Price,
                Quantity = vm.Quantity,
                PurchaseDate = DateTime.Now
            };

            _context.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}