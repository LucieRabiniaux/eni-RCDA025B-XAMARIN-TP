using System;

namespace TPModule5.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String UserPseudo { get; set; }
        public String UserName { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        public User(int userId, string userPseudo, string userName, string login, string password)
        {
            UserId = userId;
            UserPseudo = userPseudo;
            UserName = userName;
            Login = login;
            Password = password;
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}