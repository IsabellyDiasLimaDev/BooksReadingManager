using BooksAPI.Models;
using BooksAPI.Repositories;
using BooksAPI.Repositories.Interfaces;
using BooksAPI.Services.Interfaces;

namespace BooksAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync(); // necessário para persistir
        }

        public async Task<Book?> UpdateBook(Book book)
        {
            var updated = await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync(); // necessário
            return updated;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return false;

            await _bookRepository.DeleteAsync(book);
            await _bookRepository.SaveChangesAsync(); // necessário
            return true;
        }
    }
}
