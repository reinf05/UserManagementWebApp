using Microsoft.EntityFrameworkCore;
using UserManagementWebApp.Data;
using UserManagementWebApp.DTO;
using UserManagementWebApp.Interfaces;
using UserManagementWebApp.Models;

namespace UserManagementWebApp.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManagementDbContext _context;

        public UsersRepository(UserManagementDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserExist(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> UserExist(User user)
        {
            return await _context.Users.AnyAsync(u => u.Email == user.Email);
        }
    }
}
