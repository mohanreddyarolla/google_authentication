using GoogleAuthApi.Contracts;
using GoogleAuthApi.Data;
using GoogleAuthApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace GoogleAuthApi.Providers
{
    public class UserRepository: IUserRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var a = _context.User;
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            string username = _contextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.Email); 

            _context.User.Add(user);
           _context.SaveChangesAsync();
        }
    }
}
