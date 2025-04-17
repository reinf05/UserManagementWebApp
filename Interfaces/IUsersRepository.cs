using UserManagementWebApp.DTO;
using UserManagementWebApp.Models;


//Interface for the repository
namespace UserManagementWebApp.Interfaces
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> UserExist(int id);
        Task<bool> UserExist(User user);
        Task<bool> CreateUser(User userCreate);
        Task<bool> UpdateUser(User userUpdate);
        Task<bool> DeleteUser(int id);
    }
}
