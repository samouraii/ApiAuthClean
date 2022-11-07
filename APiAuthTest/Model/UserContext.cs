using Microsoft.EntityFrameworkCore;
using APiAuthTest.Model.UserModel;

namespace APiAuthTest.Model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
    }
}
