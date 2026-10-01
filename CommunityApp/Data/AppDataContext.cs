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

        public DbSet<IssueVote> IssueVotes { get; set; }

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
            //creates a composite primary key for issueVote, which eans that userid and issueid needs to be unique.
            modelBuilder.Entity<IssueVote>()
                .HasKey(v => new { v.UserId, v.IssueId });
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        public void AddIssue(Issue issue)
        {
            Issues.Add(issue);
            SaveChanges();
        }

        public void AddIssueVote(IssueVote vote)
        {
            IssueVotes.Add(vote);
            SaveChanges();
        }
        public User? SearchUser(string username)
        {
            return Users
                .FirstOrDefault(u => u.Username == username); //it returns a match or null.
        }

        public bool ContainsUser(string username)
        {
            return Users
                .Any(u => u.Username == username);
        }
        public void RemoveIssue(int issueID)
        {
            Issue? issue = Issues.FirstOrDefault(i => i.IssueId == issueID);
            if (issue != null)
            {
                Issues.Remove(issue);
                SaveChanges();
            }
        }

        public int GetLikedCount(Issue currentIssue)
        {
            int confirmCount = IssueVotes.Count(v =>
                                v.IssueId == currentIssue.IssueId &&
                                v.ConfirmedIssue);
            return confirmCount;
        }

        public int GetCompleteVoteCount(Issue currentIssue)
        {
            int completeCount = IssueVotes.Count(v =>
                                v.IssueId == currentIssue.IssueId &&
                                v.ConfirmedComplete);
            return completeCount;
        }

        public bool ChangeWorkStatus(Issue currentIssue, IssueStatus newWorkStatus)
        {

            Issue? issue = Issues.Find(currentIssue.IssueId);

            if (issue != null)
            {
                issue.WorkStatus = newWorkStatus;
                SaveChanges();
                return true;
            }
                return false;
        }

    }

}
