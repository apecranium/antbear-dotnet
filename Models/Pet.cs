using System;
using Microsoft.EntityFrameworkCore;

namespace Antbear {

  public class PetContext : DbContext {
    public PetContext(DbContextOptions<PetContext> options) : base(options) {
    }
  
    public DbSet<Pet> Pets { get; set; }
  }

  public class Pet {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
