namespace ProjektApp.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Username  { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

        public User(int id, string fullName, string username, string email, string password)
        {
            Id = id;
            FullName = fullName;
            Username = username;
            Email = email;
            this.password = password;
        }

        public User(string fullName, string username, string email, string password)
        {
            FullName = fullName;
            Username = username;
            Email = email;
            this.password = password;
        }

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
