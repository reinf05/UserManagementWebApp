using UserManagementWebApp.Models;

namespace UserManagementWebApp.Interfaces
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> UserExist(int id);
        
    }
}
