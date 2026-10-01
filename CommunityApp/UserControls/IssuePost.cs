using CommunityAppMiniProjectWinForms.Classes;
using CommunityAppMiniProjectWinForms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Windows.Forms;

namespace CommunityAppMiniProjectWinForms.Forms
{
    public partial class IssuePost : UserControl
    {
        private Issue CurrIssue; //will be used to store the issue thats passed into issuepost.

        public IssuePost(Issue issue)
        {
            CurrIssue = issue;
            using AppDataContext context = new();
            InitializeComponent();
            DepartmentAcceptIssueBtn.Hide();
            DepartmentCompleteBtn.Hide();
            DepartmentCompleteBtn.Enabled = false; // disables this button. accept button needs to be clicked first.
            UserConfirmCompleteBtn.Hide();

            if(issue.WorkStatus == IssueStatus.WaitingUserApproval)
            {
                AgreeBtn.Enabled = false; //once the work status changes to waiting user approval, it should no longer be liked.
            }

            if (AppData.CurrentUser.IsDepartment)
            {
                AgreeBtn.Enabled = false; //prevents department user from liking.
                DepartmentAcceptIssueBtn.Show();
                DepartmentCompleteBtn.Show();
                if (CurrIssue.WorkStatus == IssueStatus.InProgress)
                {
                    DepartmentAcceptIssueBtn.Enabled = false;
                    DepartmentCompleteBtn.Enabled = true; //this becomes enabled once issuestatus is in progress.
                }
                if (CurrIssue.WorkStatus == IssueStatus.WaitingUserApproval)
                {
                    //this should be disabled if its at waiting user approval stage.
                    //this is important upon program exiting and restarting.
                    DepartmentAcceptIssueBtn.Enabled = false;
                    DepartmentCompleteBtn.Enabled = false;
                }
            }
            //if they are a regular user and the issue state is waiting for usre approval, then the confirm button shows.
            if (!AppData.CurrentUser.IsDepartment && CurrIssue.WorkStatus == IssueStatus.WaitingUserApproval)
            {
                UserConfirmCompleteBtn.Show();

            }
            //assigns the data from the CURRENT issue to a control post.
            DescriptionDisplay.Text = CurrIssue.Description;
            LocationDisplay.Text = CurrIssue.Location;
            StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
            CreateIssueTimeDisplay.Text = CurrIssue.CreatedAt.ToString();
            //picture receival.
            if (!string.IsNullOrWhiteSpace(CurrIssue.ImagePath) && File.Exists(CurrIssue.ImagePath))
            {
                PictureBox1.Image = Image.FromFile(CurrIssue.ImagePath);
            }
            VoteCountDisplay.Text = context.GetLikedCount(CurrIssue).ToString();
            SubmittedByDisplay.Text = CurrIssue.User.Username; //lost upon program closure. The userid relationships helps receive it beack in loadissue().

            //Only the user that submitted the post can remove it. Therefore, the
            //remove button will only show for that user.
            //It will also show for department users.
            //// Same user data does not mean the same object reference.
            if (CurrIssue.User.UserId == AppData.CurrentUser.UserId || AppData.CurrentUser.IsDepartment)
            {
                RemovePostBtn.Show();
            }
            else
            {
                //if they are not the user that created
                RemovePostBtn.Hide();
            }
        }

        private void AgreeBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            IssueVote? vote = context.IssueVotes.Find(AppData.CurrentUser.UserId, CurrIssue.IssueId);
            if (vote == null)
            {
                vote = new(); //if vote object is null, create a new instance and set the properties.
                vote.IssueId = CurrIssue.IssueId;
                vote.UserId = AppData.CurrentUser.UserId;
                context.IssueVotes.Add(vote);
            }
            vote.ConfirmedIssue = !vote.ConfirmedIssue; //toggles true/false
            context.SaveChanges();
            VoteCountDisplay.Text = context.GetLikedCount(CurrIssue).ToString();
        }

        private void RemovePostBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            context.RemoveIssue(CurrIssue.IssueId);
            Parent?.Controls.Remove(this);
            Dispose();
            context.SaveChanges();
        }

        private string GetStatusText(IssueStatus status)
        {
            using AppDataContext context = new();
            //only half the users that liked the issue is needed to complete the vote. 
            //if it rounds down to 0, only 1 user is needed.
            int likedCount = context.GetLikedCount(CurrIssue) / 2;
            int issueFixedCount = context.GetCompleteVoteCount(CurrIssue);
            if(likedCount == 0)
            {
                likedCount = 1;
            }
            if(likedCount == issueFixedCount)
            {
                status = IssueStatus.Completed;
                UserConfirmCompleteBtn.Hide(); //hides the confirm complete button.
            }
            return status switch
            {
                IssueStatus.Submitted => "Submitted",
                IssueStatus.InProgress => "In Progress...",
                IssueStatus.WaitingUserApproval => $"Waiting for {issueFixedCount}/{likedCount} users to confirm...",
                IssueStatus.Completed => "Completed",
                _ => "Status not found." //default case.
            };
        }

        private void DepartmentAcceptIssueBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            try
            {
                //if true, database workstatus has changed.
                if (context.ChangeWorkStatus(CurrIssue, IssueStatus.InProgress))
                {
                    CurrIssue.WorkStatus = IssueStatus.InProgress; //if database has changed, just change the in memory location for display.
                    StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
                    DepartmentAcceptIssueBtn.Enabled = false;
                    DepartmentCompleteBtn.Enabled = true; //this becomes enabled when accept button gets clicked.
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Work Status cannot be changed.");
            }
        }

        private void DepartmentCompleteBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            try
            {
                //if true, database workstatus has changed.
                if (context.ChangeWorkStatus(CurrIssue, IssueStatus.WaitingUserApproval))
                {
                    CurrIssue.WorkStatus = IssueStatus.WaitingUserApproval; //if database has changed, just change the in memory location for display.
                    StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
                    DepartmentAcceptIssueBtn.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Work Status cannot be changed.");
            }
            DepartmentCompleteBtn.Enabled = false; //disables the button upon click.
        }

        private void UserConfirmCompleteBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            IssueVote? vote = context.IssueVotes.Find(AppData.CurrentUser.UserId, CurrIssue.IssueId);
            if (vote == null)
            {
                vote = new(); //if vote object is null or doesnt exsit, create a new instance and set the properties.
                vote.IssueId = CurrIssue.IssueId;
                vote.UserId = AppData.CurrentUser.UserId;
                context.IssueVotes.Add(vote);
            }
            vote.ConfirmedComplete = true; //sets to true.
            context.SaveChanges();
            StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);

        }

    }
}
