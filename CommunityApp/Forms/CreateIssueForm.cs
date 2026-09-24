using CommunityAppMiniProjectWinForms.Classes;
using CommunityAppMiniProjectWinForms.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommunityAppMiniProjectWinForms.Forms
{
    public partial class CreateIssueForm : Form
    {
        public CreateIssueForm()
        {
            InitializeComponent();
        }
        private Image? selectedImage; //this will store the image.
        private string? imagePath; //this will store the image path.
        private void CreateIssuePostBtn_Click(object sender, EventArgs e)
        {
            using AppDataContext context = new(); //to create the database object to acess SQlite database.

            if (string.IsNullOrWhiteSpace(IssueDescriptionTextbox.Text) ||
        string.IsNullOrWhiteSpace(CreateIssueLocationTextbox.Text))
            {
                MessageBox.Show("Please fill out description and location.");
                return;
            }
            else
            {
                Issue NewIssue = new Issue(IssueDescriptionTextbox.Text, CreateIssueLocationTextbox.Text, selectedImage, imagePath, AppData.CurrentUser);
                context.AddIssue(NewIssue);
                MessageBox.Show("Issue has been posted.");
                this.Close(); //closes the create issue form after posting.
            }
        }

        private void CreateIssueCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateIssueUploadBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                selectedImage = Image.FromFile(imagePath);
                pictureBox1.Image = selectedImage; //this lets you preview the image.
                CreateIssueUploadBtn.Hide();// hides the button so it doesnt block the preview image.
            }
        }

        private void CreateIssueClearImageBtn_Click(object sender, EventArgs e)
        {
            selectedImage = null;
            pictureBox1.Image = null;
            CreateIssueUploadBtn.Show();// Shows the upload button again after removing the image.

        }
    }
}
