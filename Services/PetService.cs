using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Antbear.Models;

namespace Antbear.Services {

  public class PetService {

    private readonly PetContext _context;

    public PetService(PetContext context) {
      _context = context;
    }

    public async Task<bool> PetExists(int id) {
      return await _context.Pets.AnyAsync(e => e.Id == id);
    }

    public async Task<List<Pet>> GetPets() {
      return await _context.Pets.ToListAsync();
    }

    public async Task<Pet> GetPet(int id) {
      return await _context.Pets.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Pet> CreatePet(Pet pet) {
      _context.Add(pet);
      await _context.SaveChangesAsync();
      return pet;
    }

    public async Task<Pet> UpdatePet(Pet pet) {
      _context.Update(pet);
      await _context.SaveChangesAsync();
      return pet;
    }

    public async Task DeletePet(int id) {
      var pet = await _context.Pets.FindAsync(id);
      _context.Pets.Remove(pet);
      await _context.SaveChangesAsync();
    }
  }
}
