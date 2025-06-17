using BooksAPI.Models;

namespace BooksAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveChangesAsync();
    }
}