using ORM_PB303.Dtos.AuthorDtos;
using ORM_PB303.Models;
using ORM_PB303.Services.Implementations;

//AuthorService authorService = new AuthorService();


//AuthorCreateDto author = new()
//{
//    Fullname = "Fatime edited ++++",
//    Fincode = "1234321",
//    Birthdate = DateTime.Now,
//};

//await authorService.CreateAsync(author);


BookService bookService=new BookService();

//Book book = new Book()
//{
//    Name="Book 4",
//     AuthorId=3,
//      Genre="Drama",
//        Price=20021
//};

//await bookService.CreateAsync(book);


//await bookService.DeleteAsync(4);


Book book = new()
{
    Id = 3,
    AuthorId = 4,
    Name = "Sefiller",
    Price = 999
};

await bookService.UpdateAsync(book);

var books =await bookService.GetAllAsync();

books.ForEach(x =>
{
    Console.WriteLine(x);
});


//Console.WriteLine("----------------------------------");

//var book=await bookService.GetByIdAsync(3);

//Console.WriteLine(book);