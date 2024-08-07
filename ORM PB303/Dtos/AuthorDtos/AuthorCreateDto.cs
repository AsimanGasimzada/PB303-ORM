namespace ORM_PB303.Dtos.AuthorDtos;

public class AuthorCreateDto
{
    public string Fullname { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public string Fincode { get; set; } = null!;
}
