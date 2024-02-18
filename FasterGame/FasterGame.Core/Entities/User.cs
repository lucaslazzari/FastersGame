namespace FasterGame.Core.Entities
{
    public class User
    {
        public User()
        {
        }
        public User(string fullName, string birthDate, string email, string passwords)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
            Passwords = passwords;
        }

        public int IdUser { get; private set; }
        public string FullName { get; private set; }
        public string BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Passwords { get; private set; }
        public string IdPlayer { get; private set; }
    }
}
