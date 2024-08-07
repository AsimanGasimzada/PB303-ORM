using ORM_PB303.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ORM_PB303.Models;

public class Book : BaseEntity
{
    [MaxLength(100)]
    [MinLength(3)]
    [Required]
    public string Name { get; set; } = null!;
    [Range(0, 9999)]
    public decimal Price { get; set; }
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Genre { get; set; } = null!;

    public Author Author { get; set; } = null!;
    public int AuthorId { get; set; }

}
