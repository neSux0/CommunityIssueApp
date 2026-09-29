using CommunityAppMiniProjectWinForms.Classes;
using CommunityAppMiniProjectWinForms.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace CommunityAppMiniProjectWinForms.Forms
{
    public partial class MainFeed : Form
    {
        // AppData is static, so its data remains in memory while the program is running.
        // MainFeed simply reads that data again whenever it loads.
        public MainFeed()
        {
            InitializeComponent();
            if (AppData.CurrentUser is DepartmentUser)
            {
                AddIssueBtn.Enabled = false; //prevents department user from liking.
                MainFeedTitleLabel.Text = $"Welcome, {AppData.CurrentUser.Username}!"; 
            }
            LoadIssues();
        }

        private void LoadIssues()
        {
            FeedPanel.Controls.Clear(); //this needs to be added to prevent duplicates posting.
            using AppDataContext context = new();

            foreach (Issue issue in context.Issues.Include(i => i.User)) //it uses userID relationship in each issue to get the User object.
            {
                IssuePost post = new IssuePost(issue);
                FeedPanel.Controls.Add(post);
            }
            //make each controls in the feedpanel the same length.
            foreach (Control control in FeedPanel.Controls)
            {
                control.Width = FeedPanel.ClientSize.Width;
            }
        }

        private void AddIssueBtn_Click(object sender, EventArgs e)
        {
            CreateIssueForm createForm = new CreateIssueForm();

            createForm.ShowDialog();

            LoadIssues(); //once the create form closes, it reloads the issues.
        }

        private void LogOffBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
