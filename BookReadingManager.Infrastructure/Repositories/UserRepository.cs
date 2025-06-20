using BookReadingManager.Domain.Interfaces;
using BookReadingManager.Infrastructure.Context;
using BookReadingManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReadingManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}