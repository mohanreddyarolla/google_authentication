using Google;
using GoogleAuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleAuthApi.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
