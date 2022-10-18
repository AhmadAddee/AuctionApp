namespace ProjektApp.Core
{
    public class User
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

        public User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            this.password = password;
        }

        public User(string fullName, string password)
        {
            FullName = fullName;
            this.password = password;
        }
    }
}
