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
        public DbSet<Personne> Personne { get; set; } = null!;
        public DbSet<Permissions> Permission { get; set; } = null!;
        public DbSet<societe> societe { get; set; } = null!;
        public DbSet<Contact> contacts { get; set; } = null!;
        public DbSet<MoyenDeConctact> MoyenDeConctacts { get; set; } = null!;
    }
}
