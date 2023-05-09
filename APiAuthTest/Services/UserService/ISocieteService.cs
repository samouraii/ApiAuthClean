using APiAuthTest.Model.UserModel;

namespace APiAuthTest.Services.UserService
{
    public interface ISocieteService
    {
        public Societe GetSociete(int id);
        public Societe GetSociete(string id);
    }
}
