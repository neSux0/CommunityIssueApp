using CommunityAppMiniProjectWinForms.Data;
using CommunityAppMiniProjectWinForms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommunityApp
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void UserNameLabel2_Click(object sender, EventArgs e)
        {

            //This brings the username text label to the upper top of textbox.
            UserNameLabel2.Top = 4;
            UserNameLabel2.Font = new Font(UserNameLabel2.Font.FontFamily, 6, FontStyle.Bold);
            UserNameTextBox2.Top = 20;
            UserNameTextBox2.Focus();
        }

        private void UserNameTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTextBox2.Text))
            {
                UserNameLabel2.Top = 4;

                UserNameLabel2.Font = new Font(
                    UserNameLabel2.Font.FontFamily,
                    14,
                    FontStyle.Regular
                );

                UserNameTextBox2.Top = 12;
            }
        }

        private void PasswordLabel2_Click(object sender, EventArgs e)
        {
            //This brings the username text label to the upper top of textbox.
            PasswordLabel2.Top = 4;
            PasswordLabel2.Font = new Font(UserNameLabel2.Font.FontFamily, 6, FontStyle.Bold);
            PasswordTextbox2.Top = 20;
            PasswordTextbox2.Focus();
        }

        private void PasswordTextbox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTextbox2.Text))
            {
                PasswordLabel2.Top = 4;

                PasswordLabel2.Font = new Font(
                    PasswordLabel2.Font.FontFamily,
                    14,
                    FontStyle.Regular
                );

                PasswordTextbox2.Top = 12;
            }
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new();

            string username = UserNameTextBox2.Text;
            string password = PasswordTextbox2.Text;
            ///EDGE CASES for user creation.
            if (username == "")
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be greater have 8 charachters or more.");
                return;
            }
            if (context.ContainsUser(username))
            {
                MessageBox.Show("Username already exists. Please choose another one.");
                return;
            }
            else
            {
                if (IsGov.Checked)
                {
                    context.AddUser(new DepartmentUser(username, password));
                }
                else
                {
                    context.AddUser(new PublicUser(username, password));

                }
                this.Close();
                MessageBox.Show($"Your account \"{username}\" has been created. Please log in.");
            }
        }

    }
}
