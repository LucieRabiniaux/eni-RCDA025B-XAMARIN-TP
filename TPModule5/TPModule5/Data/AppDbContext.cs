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

        public AppDbContext()
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }


        //cf : https://christophe.gigax.fr/2017/11/23/xamarin-forms-net-standard-2-0-et-entity-framework-core-avec-sqlite/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //injection de dépendances. Interface IFileHelper implémentée dans le projet Android
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("MyDb.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
