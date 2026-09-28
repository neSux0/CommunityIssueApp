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

        // DbPath gives the SQLite database a fixed location
        // so the app does not create duplicate databases from relative paths.
        //because..Update-Database uses your EF migration to create/update a SQLite database file and put the tables inside it.
        //Update-Database created one CommunityApp.db in the folder it was operating from.
        //Then when the WinForms app ran, it was operating from the compiled winForms output folder.
        public string DbPath { get; }

        public AppDataContext()
        {
           
            var folder = Environment.SpecialFolder.LocalApplicationData; //stores database in local/AppData folder.
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, "CommunityApp.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlite($"Data Source= {DbPath}");

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
        public void RemoveIssue(int issueID)
        {
            using AppDataContext context = new();
            Issue? issue = context.Issues.FirstOrDefault(i => i.IssueId == issueID);
            if (issue != null)
            {
                context.Issues.Remove(issue);
                context.SaveChanges();
            }
        }

    }

}
