using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Antbear.Models;
using Antbear.Services;

namespace Antbear.Controllers
{
  public class PetsController : Controller
  {
    private readonly PetService _petService;
    private readonly ILogger<PetsController> _logger;

    public PetsController(ILogger<PetsController> logger, PetService petService)
    {
      _logger = logger;
      _petService = petService;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _petService.GetPets());
    }

    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var pet = await _petService.GetPet(id.GetValueOrDefault());
      if (pet == null)
      {
        return NotFound();
      }
      return View(pet);
    }

    public IActionResult Create()
    {
      return View(new Pet() {
        BirthDate = DateTime.Now
      });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id, Name, BirthDate")] Pet pet)
    {
      if (ModelState.IsValid)
      {
        await _petService.CreatePet(pet);
        return RedirectToAction(nameof(Index));
      }
      return View(pet);
    }

    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var pet = await _petService.GetPet(id.GetValueOrDefault());
      if (pet == null)
      {
        return NotFound();
      }
      return View(pet);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Name, BirthDate")] Pet pet)
    {
      if (id != pet.Id)
      {
        return NotFound();
      }
      if (ModelState.IsValid)
      {
        try
        {
          await _petService.UpdatePet(pet);
        }
        catch (DbUpdateConcurrencyException error)
        {
          if (!await _petService.PetExists(pet.Id))
          {
            return NotFound();
          }
          else
          {
            _logger.LogError(error.ToString());
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(pet);
    }

    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var pet = await _petService.GetPet(id.GetValueOrDefault());
      if (pet == null)
      {
        return NotFound();
      }
      return View(pet);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _petService.DeletePet(id);
      return RedirectToAction(nameof(Index));
    }
  }
}
