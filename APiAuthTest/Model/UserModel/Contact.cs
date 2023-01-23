using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APiAuthTest.Model.UserModel
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContact { get; set; }
        public Personne personne { get; set; }
        public MoyenDeConctact typeContact { get; set; }
        [AllowNull]
        public societe societe { get; set; } = null;
        public string value { get; set; }
    }
}
