using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APiAuthTest.Model.UserModel
{
    public class MoyenDeConctact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMoyenContact { get; set; }
        public string NameContact { get; set; }
        public IEnumerable<Contact> Contacts { get; set;}

    }
}
