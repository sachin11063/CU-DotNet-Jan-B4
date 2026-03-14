using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Data;
using FinTrackPro.Models;
using System.Linq;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var accounts = _context.Accounts.ToList();
        return View(accounts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Account account)
    {
        if (ModelState.IsValid)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            TempData["Success"] = "Account created successfully";

            return RedirectToAction("Index");
        }

        return View(account);
    }

    public IActionResult Edit(int id)
{
    var account = _context.Accounts.Find(id);
    return View(account);
}

[HttpPost]
public IActionResult Edit(Account account)
{
    _context.Accounts.Update(account);
    _context.SaveChanges();

    return RedirectToAction("Index");
}

public IActionResult Delete(int id)
{
    var account = _context.Accounts.Find(id);
    return View(account);
}

[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int id)
{
    var account = _context.Accounts.Find(id);

    _context.Accounts.Remove(account);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
public IActionResult Details(int id)
{
    var account = _context.Accounts.Find(id);
    return View(account);
}
}