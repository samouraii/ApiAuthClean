using System.Security.Claims;
using APiAuthTest.Model;
using APiAuthTest.Model.UserModel;

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
    }
}
