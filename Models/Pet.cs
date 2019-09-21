using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Antbear.Models
{
  public class PetContext : DbContext
  {
    public PetContext(DbContextOptions<PetContext> options) : base(options)
    {
    }
  
    public DbSet<Pet> Pets { get; set; }
  }

  public class Pet
  {
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    public int Age
    {
      get
      {
        DateTime today = DateTime.Today;
        int age = today.Year - this.BirthDate.Year;
        if (today.Month < this.BirthDate.Month || (today.Month == this.BirthDate.Month && today.Day < this.BirthDate.Day))
        {
          age -= 1;
        }
        return age;
      }
    }
  }
}
