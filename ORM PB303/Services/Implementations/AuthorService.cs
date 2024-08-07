using Microsoft.EntityFrameworkCore;
using ORM_PB303.Context;
using ORM_PB303.Exceptions;
using ORM_PB303.Models;
using ORM_PB303.Services.Interfaces;

namespace ORM_PB303.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _context;

    public AuthorService()
    {
        _context = new AppDbContext();
    }
    public async Task CreateAsync(Author author)
    {

        var isExist = await _context.Authors.AnyAsync(x => x.Fincode.ToLower() == author.Fincode.ToLower());
        if (isExist)
        {
            Console.WriteLine("Bu fincode artiq movcuddur");
            return;
        }
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var author = await GetByIdAsync(id);

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAsync()
    {
        var authors = await _context.Authors.Include(x => x.Books).AsNoTracking().ToListAsync();

        return authors;
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

        if (author is null)
            throw new NotFoundException();

        return author;
    }

    public async Task UpdateAsync(Author author)
    {
        var existAuthor = await GetByIdAsync(author.Id);


        var isExist = await _context.Authors.AnyAsync(x => x.Fincode == author.Fincode && x.Id != author.Id);

        if (isExist)
        {
            Console.WriteLine("Bu fincode artiq movcuddur");
            return;
        }

        existAuthor.Fullname = author.Fullname;
        existAuthor.Birthdate = author.Birthdate;
        existAuthor.Fincode = author.Fincode;

        await _context.SaveChangesAsync();
    }
}
