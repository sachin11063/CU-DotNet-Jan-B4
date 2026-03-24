using Car_Management_Application.Data;
using Car_Management_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Management_Application.Controllers;

[Authorize]
public class CarController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ── VIEW CARS — All roles ─────────────────────────────────────────────────
    [Authorize(Roles = "Admin,Customer,User")]
    public async Task<IActionResult> Index()
    {
        var cars = await _context.Cars.ToListAsync();
        return View(cars);
    }

    // ── CREATE — Admin & Customer ─────────────────────────────────────────────
    [Authorize(Roles = "Admin,Customer")]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin,Customer")]
    public async Task<IActionResult> Create(Car car)
    {
        if (!ModelState.IsValid) return View(car);

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        TempData["Success"] = $"{car.Brand} {car.Model} added successfully!";
        return RedirectToAction(nameof(Index));
    }

    // ── EDIT — Admin only ─────────────────────────────────────────────────────
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id, Car car)
    {
        if (id != car.Id) return BadRequest();
        if (!ModelState.IsValid) return View(car);

        _context.Update(car);
        await _context.SaveChangesAsync();
        TempData["Success"] = $"{car.Brand} {car.Model} updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    // ── DELETE — Admin only ───────────────────────────────────────────────────
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"{car.Brand} {car.Model} deleted successfully!";
        }
        return RedirectToAction(nameof(Index));
    }
}