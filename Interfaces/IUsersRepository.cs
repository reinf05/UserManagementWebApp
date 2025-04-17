﻿using UserManagementWebApp.DTO;
using UserManagementWebApp.Models;

namespace UserManagementWebApp.Interfaces
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> UserExist(int id);
        Task<bool> UserExist(User user);
        Task<bool> CreateUser(User userCreate);
        Task<bool> UpdateUser(UserDto userUpdate);
        Task<bool> DeleteUser(int id);
    }
}
