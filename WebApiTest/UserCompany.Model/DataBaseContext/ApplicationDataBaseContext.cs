using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using UserCompany.Model.Models;

namespace UserCompany.Model.DataBaseContext
{
    public class ApplicationDataBaseContext : DbContext
    {
        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    }
}
