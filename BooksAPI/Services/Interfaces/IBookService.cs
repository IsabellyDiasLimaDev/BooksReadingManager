using BooksAPI.Models;

namespace BooksAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task<Book?> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
