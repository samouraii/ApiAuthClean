using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APiAuthTest.Model.UserModel
{
    public class PersonneDTO
    {
       
        public int? IdPersonne { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }


    }
}
