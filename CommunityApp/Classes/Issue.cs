
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CommunityAppMiniProjectWinForms.Classes;
public class Issue
{

    //===========DATA BASE===========================//
    public User User { get; set; } //navigation proprety
	//Columns of the table.
    public int UserId { get; set; } //foreign key.

    public int IssueId { get; set; } //Primary key 

    public string Description { get; set; }
	public string Location { get; set; }
	public string? ImagePath { get; set; } //stores the image path.
	public DateTime CreatedAt { get; set; } 
	public IssueStatus WorkStatus { get; set; }
	//================================================//
	[NotMapped]
    public Image? Image { get; set; }
    public string? Severity { get; set; }
    private HashSet<string> _ConfirmVotes { get; set; } //the number of users that agrees of the ongoing issue.
	private HashSet<User> _CompleteVotes { get; set; } //the number of users who agree that the work order is completed.
	private int _VotesNeeded { get; set; }

	protected Issue() { }// EF recreates an old Issue object from the database b/c EF will not be able to match the Image and CreatedByUser as they are not in the datbase.
    public Issue(string description, string location, Image? image, string? imagePath, User CreatedByUser)
    {
		//From user.
		Description = description;
		Location = location;
		Image = image;
		ImagePath = imagePath;

        WorkStatus = IssueStatus.Submitted;
		CreatedAt = DateTime.Now;

		_ConfirmVotes = new();
		_CompleteVotes = new();
		_VotesNeeded = 2; //hard coded. 2 votes are needed to complete post.
		//this keeps it convient because it allows us to track the user without having to query the database.
		User = CreatedByUser; // when an issue is created, store the user object that created that issue.
		
    }

    //==============MODIFIERS============================//
	//Both the Add/Remove like ID is used for the "like" button.
    public void AddLikedUser(string user)
	{
		_ConfirmVotes.Add(user);
	}

	public void RemoveLikedUser(string user)
	{
		_ConfirmVotes.Remove(user);
	}

    public void AddUserCompleted(User user)
    {
        _CompleteVotes.Add(user);
    }


    //====================PUBLIC PROPERTIES ACCESSORS========================//
  

	public int GetConfirmVoteCount
	{
		get { return _ConfirmVotes.Count; }
	}

	public int GetCompleteVoteCount
	{
		get { return _CompleteVotes.Count; }
	}

	public HashSet<string> UserLiked
	{
		get { return _ConfirmVotes; }
	}
	public int GetVoteNeededToComplete
	{
		get { return _VotesNeeded; }
	}

    //=============HELPER FUNCTIONS===================//
    public void ChangeWorkStatus(IssueStatus NewStatus)
    {
		WorkStatus = NewStatus;
    }
}
