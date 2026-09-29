using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using CommunityAppMiniProjectWinForms.Classes;
using CommunityAppMiniProjectWinForms.Data;

namespace CommunityAppMiniProjectWinForms.Forms
{
    public partial class IssuePost : UserControl
    {
        private Issue CurrIssue; //will be used to store the issue thats passed into issuepost.
        public IssuePost(Issue issue)
        {
            CurrIssue = issue;

            InitializeComponent();
            DepartmentAcceptIssueBtn.Hide();
            DepartmentCompleteBtn.Hide();
            UserConfirmCompleteBtn.Hide();
            if (AppData.CurrentUser.IsDepartment)
            {
                AgreeBtn.Enabled = false; //prevents department user from liking.
                DepartmentAcceptIssueBtn.Show();
                DepartmentCompleteBtn.Show();
                if (CurrIssue.WorkStatus == IssueStatus.InProgress)
                {
                    DepartmentAcceptIssueBtn.Enabled = false;
                }
                if (CurrIssue.WorkStatus == IssueStatus.WaitingUserApproval)
                {
                    DepartmentCompleteBtn.Enabled = false;
                }
            }
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
            VoteCountDisplay.Text = CurrIssue.GetConfirmVoteCount.ToString();
            SubmittedByDisplay.Text = CurrIssue.User.Username; //lost upon program closure. The userid relationships helps receive it beack in loadissue().

            //Only the user that submitted the post can remove it. Therefore, the
            //remove button will only show for that user.
            //It will also show for department users.
            if (CurrIssue.User == AppData.CurrentUser || AppData.CurrentUser.IsDepartment)
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
            if (!CurrIssue.UserLiked.Contains(AppData.CurrentUser.Username))
            {
                CurrIssue.AddLikedUser(AppData.CurrentUser.Username);
            }
            else if (CurrIssue.UserLiked.Contains(AppData.CurrentUser.Username))
            {
                CurrIssue.RemoveLikedUser(AppData.CurrentUser.Username);
            }
            VoteCountDisplay.Text = CurrIssue.GetConfirmVoteCount.ToString();
        }

        private void RemovePostBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();
            context.RemoveIssue(CurrIssue.IssueId);
            Parent?.Controls.Remove(this);
            Dispose();
        }

        private string GetStatusText(IssueStatus status)
        {
            return status switch
            {
                IssueStatus.Submitted => "Submitted",
                IssueStatus.InProgress => "In Progress...",
                IssueStatus.WaitingUserApproval => $"Waiting for {CurrIssue.GetCompleteVoteCount}/{CurrIssue.GetVoteNeededToComplete} users to confirm...",
                IssueStatus.Completed => "Completed",
                _ => "Status not found." //default case.
            };
        }

        private void DepartmentAcceptIssueBtn_Click(object sender, EventArgs e)
        {
            CurrIssue.ChangeWorkStatus(IssueStatus.InProgress);
            StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
            DepartmentAcceptIssueBtn.Enabled = false;
        }

        private void DepartmentCompleteBtn_Click(object sender, EventArgs e)
        {
            CurrIssue.ChangeWorkStatus(IssueStatus.WaitingUserApproval);
            StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
            DepartmentCompleteBtn.Enabled = false;
        }

        private void UserConfirmCompleteBtn_Click(object sender, EventArgs e)
        {
            if (CurrIssue.GetVoteNeededToComplete == CurrIssue.GetCompleteVoteCount)
            {
                CurrIssue.ChangeWorkStatus(IssueStatus.Completed);
            }
            CurrIssue.AddUserCompleted(AppData.CurrentUser);
            StatusDisplay.Text = GetStatusText(CurrIssue.WorkStatus);
            UserConfirmCompleteBtn.Enabled = false;
        }

    }
}
