using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APiAuthTest.Model.ApplicationClient;

namespace APiAuthTest.Model.UserModel
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IEnumerable<Token> token { get; set; }

        [AllowNull]
        [ForeignKey("Personne")]
        public Personne? personne { get; set; } = null!;
        [AllowNull]
       // public  List<Roles> roles{ get; set; }
        public List<Permissions> permissions { get; set; }
        [AllowNull]
        public List<GestionCaisse> CaisseEncoder { get; set; }
        

        public User(IEnumerable<Token> token = null, List<Permissions> p = null)
        {
            this.token = token?? new List<Token>();
           // this.roles = r;
            this.permissions = p;
        }
        public User()
        {
            this.token = new List<Token>();
           // this.roles = new List<Roles>();
            this.permissions = new List<Permissions>();
        }
    }
}
