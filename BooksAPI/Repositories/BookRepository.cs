using BooksAPI.Data;
using BooksAPI.Models;
using BooksAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Repositories
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
            await _context.Books.AddAsync(book);
        }

        public Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            return Task.FromResult(book);
        }

        public Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
