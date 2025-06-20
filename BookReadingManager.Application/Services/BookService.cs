using BookReadingManager.Application.Interfaces;
using BookReadingManager.Domain.Entities;
using BookReadingManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingManager.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }
        public async Task<Book?> UpdateAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
    }
}
