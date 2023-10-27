using Microsoft.EntityFrameworkCore;

namespace Assessment_IzzahShazwani.Model
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<Users> User { get; set; } = null!;
    }
}
