using APiAuthTest.Model.UserModel;

namespace APiAuthTest.Services.UserService
{
    public interface IUserService
    {
        public string GetMyName();
        public User? FindOneUser(string username);

        public bool InsertUser(User user);

        public IEnumerable<Permissions> GetPermissions(int id);
        public IEnumerable<Personne> GetPersonnes();
        public Personne GetPersonne(int id);
        public User GetUser(int id);
        public Personne PostPersonnes(Personne p);
        public void PutPersonnes(PersonneDTO p, int id);
        public Personne DelPersonnes(int id);

    }
}
