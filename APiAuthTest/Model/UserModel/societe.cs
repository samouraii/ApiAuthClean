using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APiAuthTest.Model.UserModel
{
    public class societe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSociete { get; set; }
        public string Name { get; set; }
        public string Numero { get; set; }
        public string NumTVA { get; set; }

        public IEnumerable<Personne> Personnes{get;set;}
    }
}
