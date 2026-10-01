using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using CommunityAppMiniProjectWinForms.Classes;

namespace CommunityAppMiniProjectWinForms.Data
{
    internal static class AppData
    {

        public static User? CurrentUser { get; set; } = null;
        public static bool VerifyUser(string username, string password)
        {
            using AppDataContext context = new();
            User? user = context.SearchUser(username);
            if (user == null) return false; //username not found.
            if (user.Password != password) return false; //if user found, but password wrong, return false
            CurrentUser = user; //This sets to the current user that logs in.
            return true;
        }
    }
}
