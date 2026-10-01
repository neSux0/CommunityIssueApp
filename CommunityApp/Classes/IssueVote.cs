using CommunityAppMiniProjectWinForms.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityAppMiniProjectWinForms.Classes
{
    public class IssueVote
    {
        public int UserId { get; set; } //foreign key to connect users
        public int IssueId { get; set; } //forign key to connect issues

        public bool ConfirmedIssue { get; set; } // tracks if user has liked an issues. true = liked false = liked removed.
        public bool ConfirmedComplete { get; set; } //tracks if user clicked confirmed on an issue.

    }
}
