using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AukroDbWPF.Model
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aukro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //options.UseSqlite(@"Data Source=myDatabaseFile.sqlite");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User_article>().HasKey(ua => new { ua.UserId, ua.ArticleId });
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasMaxLength(10);
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>()
                .Property(p => p.Name)
                .HasMaxLength(10);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Pepa", Password = "heslo"});
            

            modelBuilder.Entity<Article>().HasData(new Article { Id = 1, Name = "Auto", Description = "Červené a trochu rezavé", Price = 500000 });
            modelBuilder.Entity<Article>().HasData(new Article { Id = 2, Name = "Pračka", Description = "Pere dobře", Price = 4650 });
            modelBuilder.Entity<Article>().HasData(new Article { Id = 3, Name = "Pes", Description = "Žeryk, štěká, ale nekouše", Price = 1 });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User_article> User_Articles { get; set; }

    }
}
