using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Antbear.Models {

  public class PetContext : DbContext {
    public PetContext(DbContextOptions<PetContext> options) : base(options) {
    }
  
    public DbSet<Pet> Pets { get; set; }
  }

  public class Pet {
    public int Id { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
  }
}
