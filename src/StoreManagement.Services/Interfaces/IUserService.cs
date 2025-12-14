using StoreManagement.Data.Entities;

namespace StoreManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> SearchUsersAsync(string keyword);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
