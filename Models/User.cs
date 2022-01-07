namespace SignUpSignInAspNetCore.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string password;
        public User() { }
        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
