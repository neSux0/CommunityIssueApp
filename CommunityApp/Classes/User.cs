using System;
using System.DirectoryServices;

namespace CommunityAppMiniProjectWinForms.Classes;

public class User
{
	//==================DATA BASE ==============================//
	public int UserId { get; set; } //Primary key
	public virtual ICollection<Issue> Issues { get; } = new List<Issue>(); //used to navigate the issues of posted by users.
   //============================================================//
	private string _username { get; set; } //will prompt user to create
	private string _password { get; set; } //will promp user to create

    //Department privlege. If false, they are a community user. if true, they are department user.
    private bool _IsDepartment { get; set; } //Account Type
	public User(string username, string password)
	{
		_username = username;
		_password = password;
	}

	//makes username readable.
	public string Username
	{
		get { return _username; }
	}
	public string Password
	{
		get { return _password; }
	}

	public bool IsDep
	{
		get { return _IsDepartment; }
	}
}
