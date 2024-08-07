using ORM_PB303.Models;
using ORM_PB303.Services.Implementations;

AuthorService authorService = new AuthorService();


Author author = new Author()
{
    Id = 3,
    Fullname = "Fatime edited ++++",
    Fincode = "1234545",
    Birthdate = DateTime.Now,
};

await authorService.UpdateAsync(author);