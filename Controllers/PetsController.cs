using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antbear.Models;

namespace Antbear.Controllers {

  public class PetsController : Controller {

    private readonly PetContext _context;

    public PetsController(PetContext context) {
      _context = context;
    }

    public async Task<IActionResult> Index() {
      return View(await _context.Pets.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var pet = await _context.Pets.FirstOrDefaultAsync(m => m.Id == id);
      if (pet == null) {
        return NotFound();
      }

      return View(pet);
    }

    public IActionResult Create() {
      return View(new Pet {
        BirthDate = DateTime.Now
      });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id, Name, BirthDate")] Pet pet) {
      if (ModelState.IsValid) {
        _context.Add(pet);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(pet);
    }
  }
}
