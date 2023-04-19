using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
        Task<long> AddUserAsync(UserModel userModel);
        Task UpdateUserAsync(int userId, UserModel userModel);
        Task DeleteUserAsync(int userId);
    }
}
