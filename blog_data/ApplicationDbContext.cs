using blog_models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace blog_data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbo) : base(dbo)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name = "General" },
                    new Category() { Id = 2, Name = "Technology" },
                    new Category() { Id = 3, Name = "Random" });
            modelBuilder.Entity<Post>().HasData(
                    new Post()
                    {
                        Id = 1,
                        CategoryId = 2,
                        TimeStamp = DateTime.Now,
                        Title= "Why you should use TypeScript for writing Cloud Functions",
                        Content = "<p>Are you looking for something new to learn this year?  Then let me suggest <a href=\\\"http://www.typescriptlang.org/\\\">TypeScript</a> for development with Cloud Functions!</p><p>Not long ago, the Cloud Functions for Firebase team <a href=\\\"http://firebase.googleblog.com/2017/12/improve-productivity-with-typescript.html\\\">released an update</a> to the <a href=\\\"https://firebase.google.com/docs/cli/\\\">Firebase CLI</a> that makes it easy for you to write your functions in TypeScript, rather than JavaScript.  The Firebase team encourages you to consider switching to TypeScript, but I can imagine you might be reluctant to learn a new language, especially if you're already comfortable with JavaScript.  The great news is that TypeScript offers you a bunch of benefits that are easy to start using today.</p>"
                    },
                    new Post()
                    {
                        Id = 2,
                        CategoryId = 2,
                        TimeStamp = DateTime.Now,
                        Title = "Introducing Query-based Security Rules",
                        Content = "<p>Securing your Firebase Realtime Database just got easier with our newest feature: <strong>query-based rules</strong>. Query-based rules allow you to limit access to a subset of data. Need to restrict a query to return a maximum of 10 records? Want to ensure users are only retrieving the first 20 records instead of the last 20? Want to let a user query for only their documents? Not a problem. Query-based rules has you covered. Query-based rules can even help you simplify your data structure. Read on to learn how!</p>"
                    }) ; 
        }
    }
}
