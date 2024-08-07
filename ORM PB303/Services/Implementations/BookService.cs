using Microsoft.EntityFrameworkCore;
using ORM_PB303.Context;
using ORM_PB303.Exceptions;
using ORM_PB303.Models;
using ORM_PB303.Services.Interfaces;

namespace ORM_PB303.Services.Implementations;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService()
    {
        _context = new AppDbContext();
    }
    public async Task CreateAsync(Book book)
    {
        var isExist = await _context.Books.AnyAsync(x => x.Name.ToLower() == book.Name.ToLower());

        if(isExist)
        {
            Console.WriteLine("Bu kitab artiq movcuddur");
            return;
        }

        var isExistAuthor = await _context.Authors.AnyAsync(x => x.Id == book.AuthorId);

        if (!isExistAuthor)
        {
            Console.WriteLine("Author tapilmadi");
            return;
        }

        if (book.Price < 0)
        {
            Console.WriteLine("Price 0 dan kicik ola bilmez");
            return;
        }

        book.Id = 0;

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var book=await GetByIdAsync(id);


        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = await _context.Books.Include(x=>x.Author).ToListAsync();

        return books;
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _context.Books.Include(x=>x.Author).FirstOrDefaultAsync(x => x.Id == id);

        if (book is null)
            throw new NotFoundException();

        return book;    

    }

    public async Task UpdateAsync(Book book)
    {
        var existBook = await GetByIdAsync(book.Id);



        var isExist = await _context.Books.AnyAsync(x => x.Name.ToLower() == book.Name.ToLower() && x.Id!=book.Id);

        if (isExist)
        {
            Console.WriteLine("Bu kitab artiq movcuddur");
            return;
        }

        var isExistAuthor = await _context.Authors.AnyAsync(x => x.Id == book.AuthorId);

        if (!isExistAuthor)
        {
            Console.WriteLine("Author tapilmadi");
            return;
        }

        if (book.Price < 0)
        {
            Console.WriteLine("Price 0 dan kicik ola bilmez");
            return;
        }


        existBook.AuthorId= book.AuthorId;
        existBook.Name=book.Name;
        existBook.Price= book.Price;

        await _context.SaveChangesAsync();
    }
}
