using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Antbear.Models
{
  public class Pet
  {
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string Name { get; set; }

    [Required]
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
