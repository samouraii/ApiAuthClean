using APiAuthTest.Model.UserModel;

namespace APiAuthTest.Services.UserService
{
    public interface IUserService
    {
        public string GetMyName();
        public User? FindOneUser(string username);

        public bool InsertUser(User user);
    }
}
