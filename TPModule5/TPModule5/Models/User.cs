using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPModule5.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public String UserPseudo { get; set; }
        public String UserName { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        public User() { }

        public User(string userPseudo, string userName, string login, string password)
        {
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