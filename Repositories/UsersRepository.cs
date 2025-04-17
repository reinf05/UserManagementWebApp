using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementWebApp.Data;
using UserManagementWebApp.DTO;
using UserManagementWebApp.Interfaces;
using UserManagementWebApp.Models;

//Repository to seperate the context and the API
//This makes the code more modular, restricts the use of the database context, which makes the app more secure
namespace UserManagementWebApp.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManagementDbContext _context;

        //Connects to the dbContext upon creation
        public UsersRepository(UserManagementDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            _context.Remove(user);
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

        public async Task<bool> UpdateUser(User user)
        {
            _context.Update(user);
            return await _context.SaveChangesAsync() > 0;
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
