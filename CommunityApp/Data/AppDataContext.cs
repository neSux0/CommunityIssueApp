using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CommunityAppMiniProjectWinForms.Classes
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlite("Data Source=Users.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this reduces time comepcity of username search in the worst case from O(n) to O(logn).
 
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username) 
                .IsUnique();
        }

        public void AddUser(User user)
        {
            using AppDataContext context = new();
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void AddIssue(Issue issue)
        {
            using AppDataContext context = new();
            context.Issues.Add(issue);
            context.SaveChanges();
        }
        public User? SearchUser(string username)
        {
            using AppDataContext context = new();
            return context.Users
                .FirstOrDefault(u => u.Username == username); //it returns a match or null.
        }

        public bool ContainsUser(string username)
        {
            using AppDataContext context = new();
            return context.Users
                .Any(u => u.Username == username);
        }

    }

}
