using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APiAuthTest.Model.ApplicationClient;

namespace APiAuthTest.Model.UserModel
{
    public class Societe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSociete { get; set; }
        public string Name { get; set; }
        public string Numero { get; set; }
        public string NumTVA { get; set; }

        public IEnumerable<Personne> Personnes{get;set;}
        public List<GestionCaisse> caisse { get; set; }
    }
}
