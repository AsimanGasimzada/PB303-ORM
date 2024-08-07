using ORM_PB303.Models.Common;

namespace ORM_PB303.Models;

public class Author : BaseEntity
{
    public string Fullname { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public string Fincode { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();



}