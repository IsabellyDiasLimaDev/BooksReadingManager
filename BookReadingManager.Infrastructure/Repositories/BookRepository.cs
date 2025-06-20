using BookReadingManager.Domain.Entities;
using BookReadingManager.Domain.Interfaces;
using BookReadingManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookReadingManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> UpdateAsync(Book updatedBook)
        {
            var existingBook = await _context.Books.FindAsync(updatedBook.Id);
            if (existingBook == null) return null;

            _context.Entry(existingBook).CurrentValues.SetValues(updatedBook);

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
