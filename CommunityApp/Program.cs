
using CommunityAppMiniProjectWinForms.Classes;
using Microsoft.EntityFrameworkCore;

namespace CommunityAppMiniProjectWinForms;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        using AppDataContext context = new();

        MessageBox.Show(
            context.Database.GetDbConnection().DataSource
        );
        Application.Run(new LogInForm());
    }
}