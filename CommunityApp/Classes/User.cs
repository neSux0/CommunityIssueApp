using System;
using System.DirectoryServices;

namespace CommunityAppMiniProjectWinForms.Classes;

public class User
{
	//==================DATA BASE ==============================//
	public int UserId { get; set; } //Primary key
	public virtual ICollection<Issue> Issues { get; } = new List<Issue>(); //used to navigate the issues of posted by users.
   //============================================================//
	public string Username { get; set; } //will prompt user to create
	public string Password { get; set; } //will promp user to create

    //Department privlege. If false, they are a community user. if true, they are department user.
    public bool IsDepartment { get; set; } //Account Type
	public User(string username, string password)
	{
		Username = username;
		Password = password;
	}
}
