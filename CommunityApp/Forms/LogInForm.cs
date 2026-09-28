using CommunityAppMiniProjectWinForms.Data;
using CommunityAppMiniProjectWinForms.Forms;
using System.Data;

namespace CommunityAppMiniProjectWinForms
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();

        }

        private void UserNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTextBox.Text))
            {
                UserNameLabel.Top = 4;

                UserNameLabel.Font = new Font(
                    UserNameLabel.Font.FontFamily,
                    14,
                    FontStyle.Regular
                );

                UserNameTextBox.Top = 12;
            }
        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {
            //This brings the username text label to the upper top of textbox.
            UserNameLabel.Top = 4;
            UserNameLabel.Font = new Font(UserNameLabel.Font.FontFamily, 6, FontStyle.Bold);

            UserNameTextBox.Top = 20;
            UserNameTextBox.Focus();
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            //validate user log in input.
            if(string.IsNullOrWhiteSpace(UserNameTextBox.Text) || string.IsNullOrEmpty(PasswordTextbox.Text))
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            if(ValidateLogIn(UserNameTextBox.Text, PasswordTextbox.Text))
            {
                MessageBox.Show("Logging in...");
                this.Hide(); // the log in form must be hidden first otherwise it would cloes the entire program.
                MainFeed mainfeed = new();
                mainfeed.ShowDialog();
                //upon mainfeed exiting, log in page reappears with textfield cleared.
                UserNameTextBox.Clear();
                PasswordTextbox.Clear();
                this.Show();

            }
            else
            {
                MessageBox.Show("Your username or password is incorrect.");
                return;
            }

        }
        private void createBtn_Click(object sender, EventArgs e)
        {
            CreateAccountForm CreateForm = new CreateAccountForm();
            CreateForm.ShowDialog();
        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {
            //This brings the password text label to the upper top of textbox.
            PasswordLabel.Top = 4;
            PasswordLabel.Font = new Font(PasswordLabel.Font.FontFamily, 6, FontStyle.Bold);

            PasswordTextbox.Top = 20;
            PasswordTextbox.Focus();
        }

        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTextbox.Text))
            {
                PasswordLabel.Top = 4;

                PasswordLabel.Font = new Font(
                    UserNameLabel.Font.FontFamily,
                    14,
                    FontStyle.Regular
                );

                PasswordTextbox.Top = 12;
            }
        }


        //===============HELPER METHODS===================================//

        public bool ValidateLogIn(string user, string pass)
        {
            return (AppData.VerifyUser(user, pass));
        }
    }
}
