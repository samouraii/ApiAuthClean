using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APiAuthTest.Model.UserModel
{
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> users { get; set; }
        public List<Roles> roles { get; set; }
        public Permissions()
        {
            users= new List<User>();
            roles= new List<Roles>();
        }
        public Permissions(List<User> users)
        {
            this.users = users;
            roles = new List<Roles>();
        }

    }
}
