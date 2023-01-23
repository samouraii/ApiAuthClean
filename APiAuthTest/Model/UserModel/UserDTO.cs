namespace APiAuthTest.Model.UserModel
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Personne? personne { get; set; }

    }
}
