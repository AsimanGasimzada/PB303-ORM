using ORM_PB303.Models;

namespace ORM_PB303.Services.Interfaces;

public interface IAuthorService
{
    Task CreateAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(int id);
    Task<List<Author>> GetAllAsync();
    Task<Author> GetByIdAsync(int id);
}
