using ORM_PB303.Models;

namespace ORM_PB303.Services.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task CreateAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
}
