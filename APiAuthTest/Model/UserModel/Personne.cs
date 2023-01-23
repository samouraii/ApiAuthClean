using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APiAuthTest.Model.UserModel
{
    public class Personne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersonne { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
      
        public User? user { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<societe> Societes { get; set; }

    }
    public class PersonneDT0
    {
      
       
        public string Name { get; set; }
        public string FirstName { get; set; }

       
    }
}
