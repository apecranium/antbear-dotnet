using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Antbear.Models;

namespace Antbear.Services
{
  public class PetService : IService<Pet>
  {
    private readonly AppDbContext _context;

    public PetService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<bool> Exists(int id)
    {
      return await _context.Pets.AnyAsync(e => e.Id == id);
    }

    public async Task<List<Pet>> GetAll()
    {
      return await _context.Pets.ToListAsync();
    }

    public async Task<Pet> GetOne(int id)
    {
      return await _context.Pets.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Pet> Create(Pet pet)
    {
      var p = new Pet() {
        Name = pet.Name,
        BirthDate = pet.BirthDate
      };
      _context.Add(p);
      await _context.SaveChangesAsync();
      return p;
    }

    public async Task<Pet> Update(Pet pet)
    {
      var p = new Pet() {
        Name = pet.Name,
        BirthDate = pet.BirthDate
      };
      _context.Update(p);
      await _context.SaveChangesAsync();
      return p;
    }

    public async Task Delete(int id)
    {
      var pet = await _context.Pets.FindAsync(id);
      _context.Pets.Remove(pet);
      await _context.SaveChangesAsync();
    }
  }
}
