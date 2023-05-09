using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APiAuthTest.Model.UserModel;
using Microsoft.EntityFrameworkCore;

namespace APiAuthTest.Model.ApplicationClient
{
    public class GestionCaisse
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCaisse {get;set;} 
        [DataType(DataType.DateTime)]
        public DateTime DateEnregistrement { get; set; } = new DateTime();
        public int Billet500 { get; set; } = 0;
        public int Billet200 { get; set; } = 0;
        public int Billet100 { get; set; } = 0;
        public int Billet050 { get; set; } = 0;
        public int Billet020 { get; set; } = 0;
        public int Billet010 { get; set; } = 0;
        public int Billet005 { get; set; } = 0;
        public int Billet002 { get; set; } = 0;
        public int Billet001 { get; set; } = 0;
        public int Piece50 { get; set; } = 0;
        public int Piece20 { get; set; } = 0;
        public int Piece10 { get; set; } = 0;
        public int Piece05 { get; set; } = 0;
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public double TotalBancontact { get; set; } = 0;
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public double TotalRetrait { get; set; } = 0;
        public int NbBiere { get; set; } = 0;
        
        [ForeignKey("Societe")]
        public Societe societe { get; set; }
        [ForeignKey("User")]
        public User EncoderPar { get; set; }
        [DataType(DataType.Text)]
        public string Commentaire { get; set; }
       
        
        public double TotalCash()
        {
            
                double total = Billet500 * 500 + Billet200 * 200 + Billet100 * 100 + Billet050 * 50;
                total += Billet020 * 20 + Billet010 * 10 + Billet005 * 5+ Billet002 * 2 + Billet001 *1 + Piece50 * 0.5 + Piece20 * 0.2
                    + Piece10 * 0.1 + Piece05 * 0.05 + TotalBancontact*1.0  ;
                return total;
            
        }

    }

    public class GestionCaisseDto
    {


        public int? Id { get; set; } 

        public DateTime DateCaisse { get; set; }
        
        public int Billet500 { get; set; } = 0;
        public int Billet200 { get; set; } = 0;
        public int Billet100 { get; set; } = 0;
        public int Billet050 { get; set; } = 0;
        public int Billet020 { get; set; } = 0;
        public int Billet010 { get; set; } = 0;
        public int Billet005 { get; set; } = 0;
        public int Billet002 { get; set; } = 0;
        public int Billet001 { get; set; } = 0;
        public int Piece50 { get; set; } = 0;
        public int Piece20 { get; set; } = 0;
        public int Piece10 { get; set; } = 0;
        public int Piece05 { get; set; } = 0;
      
        public double TotalBancontact { get; set; } = 0;
      
        public double TotalRetrait { get; set; } = 0;
        public int NbBiere { get; set; } = 0;

        public string societe { get; set; }
       // public int EncoderPar { get; set; }
      
        public string? Commentaire { get; set; }
        public double TotalCash
        {
            get;set;
        }
        public double Balance { get; set; }
        public string CodeMois { get; set; }
    }
}
