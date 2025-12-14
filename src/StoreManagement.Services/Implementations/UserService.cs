using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.Query()
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
             return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string keyword)
        {
             if (string.IsNullOrWhiteSpace(keyword))
                return await _userRepository.GetAllAsync();

            return await _userRepository.Query()
                .Where(u => u.Username.Contains(keyword) || (u.FullName != null && u.FullName.Contains(keyword)))
                .ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            // Validate unique username logic could be here
             await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
             await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
             await _userRepository.DeleteAsync(id);
        }
    }
}
