using GoogleAuthApi.Models;

namespace GoogleAuthApi.Contracts
{
    public interface IUserRepository
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task AddUserAsync(User user);
    }
}
