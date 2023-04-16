using APiAuthTest.Model;
using APiAuthTest.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace APiAuthTest.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserContext _UserContext;
        public UserService(IHttpContextAccessor httpContextAccessor, UserContext userContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _UserContext = userContext;
        }
        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

      

        public User? FindOneUser(string username)
        {
            User? u = _UserContext.Users.FirstOrDefault(s => s.Username == username);
            return u;
        }

        public bool InsertUser(User user)
        {
            try {
                _UserContext.Users.Add(user);
                _UserContext.SaveChanges();
                return true;
            }
            catch { return false; }
             
        }

        public IEnumerable<Permissions> GetPermissions(int id)
        {
            User u = _UserContext.Users.Include(x=> x.permissions).First<User>(u => u.Id == id);
            List<Permissions> permissions = new List<Permissions>();
            // u.roles.ForEach(r => permissions.AddRange(r.permissions));
            permissions.AddRange(u.permissions);

            //_UserContext.Permission.Include(x => x.users) .StudentCourses.Include(x => x.Student).Where(entry => entry.CourseId == theIdYouWant).Select(entry => entry.Student)
            return permissions.Distinct<Permissions>();
           
        }

        public IEnumerable<Personne> GetPersonnes()
        {
            return _UserContext.Personne;
           
        }
        public Personne GetPersonne(int id)
        {
            return _UserContext.Personne.First(p => p.IdPersonne == id);
        }

        public Personne PostPersonnes(Personne p)
        {
            _UserContext.Personne.Add(p);
            _UserContext.SaveChanges();
            return p;
        }

        public void PutPersonnes(PersonneDTO p, int id)
        {
            Personne pE = GetPersonne(id);

            if (pE == null) throw new Exception("Not Valide argument");
            
            pE.FirstName = p.FirstName;
            pE.Name = p.Name;

            _UserContext.Personne.Update(pE);
            _UserContext.SaveChanges();

        }

        public Personne DelPersonnes(int id)
        {
            Personne p = GetPersonne(id);
            _UserContext.Personne.Remove(p);
            return p;
        }

        public User GetUser(int id)
        {
            return _UserContext.Users.First(p => p.Id == id);
        }
    }
}
