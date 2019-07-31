using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalLibrary.Models
{
  public class Book
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string TitleOfTheBook { get; set; }
    [MinLength(4)]
    public string YearOfPublishing { get; set; }
    [Required]
    public LibraryInfo Category { get; set; }
    [Required]
    public string ShortDescription { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
