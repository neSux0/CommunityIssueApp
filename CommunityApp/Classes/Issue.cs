
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
namespace CommunityAppMiniProjectWinForms.Classes;
public class Issue
{

    //===========DATA BASE===========================//
    public User User { get; set; }
    public int UserId { get; set; } //foreign key.

    public int IssueId { get; set; } //Primary key 

    //================================================//
    private string _description { get; set; }
	private string _location { get; set; }
	private Image? _Image { get; set; } //stores the image object in memory.
	private DateTime _CreatedAt { get; set; }
	private string _severity { get; set; }
	private IssueStatus _WorkStatus { get; set; }
	private HashSet<string> _ConfirmVotes { get; set; } //the number of users that agrees of the ongoing issue.
	private HashSet<User> _CompleteVotes { get; set; } //the number of users who agree that the work order is completed.
	private int _VotesNeeded { get; set; }

    public Issue(string description, string location, Image? image, User CreatedByUser)
    {
		//From user.
		_description = description;
		_location = location;
		_Image = image;

        _WorkStatus = IssueStatus.Submitted;
		_CreatedAt = DateTime.Now;
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
    public string Description
	{
		get { return _description; }
	}
    public string Location
    {
        get { return _location; }
    }

    public IssueStatus WorkStatus
    {
        get { return _WorkStatus; }
    }

	public int GetConfirmVoteCount
	{
		get { return _ConfirmVotes.Count; }
	}

	public int GetCompleteVoteCount
	{
		get { return _CompleteVotes.Count; }
	}
	public DateTime CreatedAt
	{
		get {return _CreatedAt; }
	}

	public Image? GetImage
	{
		get { return _Image; }
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
		_WorkStatus = NewStatus;
    }
}
