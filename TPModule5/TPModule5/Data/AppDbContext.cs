using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TPModule5.Models;
using TPModule5.Services;
using Xamarin.Forms;

namespace TPModule5.Data
{
    class AppDbContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext()
        {
            //check si la BDD est créée
            if (this.Database.EnsureCreated())
            {
                //injection des données
                //users
                User user1 = new User() { UserPseudo = "Lyse", UserName = "Lucie", Login = "lucie", Password = "123456" };
                User user2 = new User() { UserPseudo = "Matis", UserName = "Mathias", Login = "matt", Password = "123456" };
                User user3 = new User() { UserPseudo = "Flo", UserName = "Florian", Login = "flo", Password = "123456" };
                Users.Add(user1);
                Users.Add(user2);
                Users.Add(user3);
                this.SaveChanges();

                ////tweets
                var listTweetToPersist = new List<Tweet> {
                new Tweet(){ CreationDate = "50s", Text = "Nullam id accumsan ipsum. Nunc ullamcorper at velit ac semper. Integer vestibulum, lectus vitae pretium interdum, dui nibh auctor lectus.", User = user1 },
                new Tweet(){ CreationDate = "20s",Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi tincidunt erat eu sapien congue, a scelerisque magnaum lacus, vitae dignissim erat", User = user2},
                new Tweet(){ CreationDate = "10s",Text = "Ut vel lobortis enim. Pellentesque nisi lorem, mollis quis tellus eget, tincidunt maximus ante.", User = user3 }
                };
                foreach (var tweet in listTweetToPersist)
                {
                    Tweets.Add(tweet);
                }
                this.SaveChanges();

            }


        }

        //cf : https://christophe.gigax.fr/2017/11/23/xamarin-forms-net-standard-2-0-et-entity-framework-core-avec-sqlite/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //injection de dépendances. Interface IFileHelper implémentée dans le projet Android
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("MyDb.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
