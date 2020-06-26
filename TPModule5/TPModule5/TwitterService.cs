using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TPModule5.Data;
using TPModule5.Models;
using TPModule5.Services;

namespace TPModule5
{
    public class TwitterService : ITwitterService
    {

        //propriété en lecture seule (renvoie une liste de tweets factices)
        public List<Tweet> ListTweets
        {
            get
            {
                return new List<Tweet> {
                new Tweet("50s","Nullam id accumsan ipsum. Nunc ullamcorper at velit ac semper. Integer vestibulum, lectus vitae pretium interdum, dui nibh auctor lectus.",
                new User("Lyse","Lucie","lucie","123456")),
                new Tweet("20s","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi tincidunt erat eu sapien congue, a scelerisque magnaum lacus, vitae dignissim erat",
                new User("Matis","Mathias","matt","123456")),
                new Tweet("10s","Ut vel lobortis enim. Pellentesque nisi lorem, mollis quis tellus eget, tincidunt maximus ante.",
                new User("Flo","Florian","flo","123456")),
                };
            }
        }


        public bool Authenticate(User user)
        {
            bool isValid = true;

            //vérifier si l'utilisateur possède au moins un tweet dans la liste de tweets
            var listTweets = GetTweets();
            if(!listTweets.Select(u => u.User).Any(u => u.Login == user.Login && u.Password == user.Password))
            {
                isValid = false;
                Debug.WriteLine("non");
            }

            return isValid;
        }

        public List<Tweet> GetTweets()
        {
            var context = new AppDbContext();
            var listTweets = context.Tweets.Include(t => t.User).ToList();
            
            //test
            //var listTweets = context.Tweets.Include(t => t.User).Where(t => t.User.UserPseudo == "Flo").ToList();

            return listTweets;
        }
    }
}
