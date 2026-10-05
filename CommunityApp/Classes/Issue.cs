
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

    // Used by EF Core to recreate Issue objects from database data
    // without calling the normal constructor.
    //EF creates an empty object first, then fills its mapped properties with values from the database.
    protected Issue() { }
    public Issue(string description, string location, Image? image, string? imagePath, User CreatedByUser)
    {
		//From user.
		Description = description;
		Location = location;
		Image = image;
		ImagePath = imagePath;

        WorkStatus = IssueStatus.Submitted;
		CreatedAt = DateTime.Now;
		//this keeps it convient because it allows us to track the user without having to query the database.
		UserId = CreatedByUser.UserId; // when an issue is created, store the user object that created that issue.
		
    }
  



}
