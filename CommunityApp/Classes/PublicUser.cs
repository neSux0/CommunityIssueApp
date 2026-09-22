using System;
namespace CommunityAppMiniProjectWinForms.Classes;

public class PublicUser : User
{
	public PublicUser(string name, string password) : base(name,password)
	{
		IsDepartment = false;
	}


}
