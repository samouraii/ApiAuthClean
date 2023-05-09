using APiAuthTest.Model;
using APiAuthTest.Model.UserModel;

namespace APiAuthTest.Services.UserService
{
    public class SocieteService : ISocieteService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserContext _UserContext;
        public SocieteService(IHttpContextAccessor httpContextAccessor, UserContext userContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _UserContext = userContext;
        }

        public Societe GetSociete(int id)
        {
            Societe u = _UserContext.societe.First(s => s.IdSociete == id);
            return u;
        }
        public Societe? GetSociete(string id)
        {
            Societe? u = _UserContext.societe.FirstOrDefault(s => s.Name == id);
            return u;
        }
    }
}
