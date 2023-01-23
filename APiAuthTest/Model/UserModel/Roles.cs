using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APiAuthTest.Model.UserModel
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public List<Permissions> permissions { get; set; }

        //public List<User> users { get; set; }
        public Roles() {
            permissions = new List<Permissions>();
           // users = new List<User>();
        }
        public Roles(List<Permissions> p = null/*, List<User> user = null*/)
        {
            permissions = p;
           // users = user;
        }
    }
}
