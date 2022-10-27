namespace APiAuthTest.Services.UserService
{
    public interface IUserService
    {
        public string GetMyName();
        public User FindOneUser(string unsername);

        public void InsertUser(User user);
    }
}
