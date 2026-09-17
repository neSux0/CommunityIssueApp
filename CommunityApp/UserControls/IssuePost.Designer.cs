namespace CommunityAppMiniProjectWinForms.Forms
{
    partial class IssuePost
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox1 = new PictureBox();
            DescriptionLabel = new Label();
            LocationLabel = new Label();
            StatusLabel = new Label();
            AgreeBtn = new Button();
            StatusDisplay = new Label();
            VoteCountDisplay = new Label();
            DescriptionDisplay = new Label();
            LocationDisplay = new Label();
            CreateIssuetimeLabel = new Label();
            CreateIssueTimeDisplay = new Label();
            RemovePostBtn = new Button();
            SubmittedByLabel = new Label();
            SubmittedByDisplay = new Label();
            DepartmentAcceptIssueBtn = new Button();
            DepartmentCompleteBtn = new Button();
            UserConfirmCompleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new Point(73, 32);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(479, 205);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DescriptionLabel.ForeColor = Color.Firebrick;
            DescriptionLabel.Location = new Point(9, 290);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(114, 25);
            DescriptionLabel.TabIndex = 1;
            DescriptionLabel.Text = "Description:";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LocationLabel.ForeColor = Color.Firebrick;
            LocationLabel.Location = new Point(33, 326);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(90, 25);
            LocationLabel.TabIndex = 2;
            LocationLabel.Text = "Location:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            StatusLabel.ForeColor = Color.Firebrick;
            StatusLabel.Location = new Point(53, 255);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(70, 25);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Status:";
            // 
            // AgreeBtn
            // 
            AgreeBtn.BackColor = SystemColors.Window;
            AgreeBtn.FlatAppearance.BorderSize = 0;
            AgreeBtn.FlatStyle = FlatStyle.Flat;
            AgreeBtn.Font = new Font("Segoe UI", 9F);
            AgreeBtn.ForeColor = SystemColors.ActiveCaptionText;
            AgreeBtn.Location = new Point(9, 64);
            AgreeBtn.Name = "AgreeBtn";
            AgreeBtn.Size = new Size(30, 34);
            AgreeBtn.TabIndex = 6;
            AgreeBtn.Text = "👍";
            AgreeBtn.UseVisualStyleBackColor = false;
            AgreeBtn.Click += AgreeBtn_Click;
            // 
            // StatusDisplay
            // 
            StatusDisplay.AutoSize = true;
            StatusDisplay.Location = new Point(129, 255);
            StatusDisplay.Name = "StatusDisplay";
            StatusDisplay.Size = new Size(19, 25);
            StatusDisplay.TabIndex = 11;
            StatusDisplay.Text = "-";
            // 
            // VoteCountDisplay
            // 
            VoteCountDisplay.AutoSize = true;
            VoteCountDisplay.Location = new Point(33, 69);
            VoteCountDisplay.Name = "VoteCountDisplay";
            VoteCountDisplay.Size = new Size(22, 25);
            VoteCountDisplay.TabIndex = 12;
            VoteCountDisplay.Text = "0";
            // 
            // DescriptionDisplay
            // 
            DescriptionDisplay.AutoSize = true;
            DescriptionDisplay.Location = new Point(129, 290);
            DescriptionDisplay.Name = "DescriptionDisplay";
            DescriptionDisplay.Size = new Size(19, 25);
            DescriptionDisplay.TabIndex = 13;
            DescriptionDisplay.Text = "-";
            // 
            // LocationDisplay
            // 
            LocationDisplay.AutoSize = true;
            LocationDisplay.Location = new Point(129, 326);
            LocationDisplay.Name = "LocationDisplay";
            LocationDisplay.Size = new Size(19, 25);
            LocationDisplay.TabIndex = 14;
            LocationDisplay.Text = "-";
            // 
            // CreateIssuetimeLabel
            // 
            CreateIssuetimeLabel.AutoSize = true;
            CreateIssuetimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CreateIssuetimeLabel.ForeColor = Color.Firebrick;
            CreateIssuetimeLabel.Location = new Point(3, 360);
            CreateIssuetimeLabel.Name = "CreateIssuetimeLabel";
            CreateIssuetimeLabel.Size = new Size(121, 25);
            CreateIssuetimeLabel.TabIndex = 15;
            CreateIssuetimeLabel.Text = "Time Posted:";
            // 
            // CreateIssueTimeDisplay
            // 
            CreateIssueTimeDisplay.AutoSize = true;
            CreateIssueTimeDisplay.Location = new Point(130, 360);
            CreateIssueTimeDisplay.Name = "CreateIssueTimeDisplay";
            CreateIssueTimeDisplay.Size = new Size(19, 25);
            CreateIssueTimeDisplay.TabIndex = 16;
            CreateIssueTimeDisplay.Text = "-";
            // 
            // RemovePostBtn
            // 
            RemovePostBtn.FlatAppearance.BorderSize = 0;
            RemovePostBtn.FlatStyle = FlatStyle.Flat;
            RemovePostBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RemovePostBtn.ForeColor = Color.Firebrick;
            RemovePostBtn.Location = new Point(590, 0);
            RemovePostBtn.Name = "RemovePostBtn";
            RemovePostBtn.Size = new Size(35, 29);
            RemovePostBtn.TabIndex = 17;
            RemovePostBtn.Text = "X";
            RemovePostBtn.UseVisualStyleBackColor = true;
            RemovePostBtn.Click += RemovePostBtn_Click;
            // 
            // SubmittedByLabel
            // 
            SubmittedByLabel.AutoSize = true;
            SubmittedByLabel.Font = new Font("Segoe UI", 6F);
            SubmittedByLabel.Location = new Point(444, 398);
            SubmittedByLabel.Name = "SubmittedByLabel";
            SubmittedByLabel.Size = new Size(81, 15);
            SubmittedByLabel.TabIndex = 18;
            SubmittedByLabel.Text = "Submitted By:";
            // 
            // SubmittedByDisplay
            // 
            SubmittedByDisplay.AutoSize = true;
            SubmittedByDisplay.Font = new Font("Segoe UI", 7F);
            SubmittedByDisplay.Location = new Point(531, 394);
            SubmittedByDisplay.Name = "SubmittedByDisplay";
            SubmittedByDisplay.Size = new Size(15, 19);
            SubmittedByDisplay.TabIndex = 19;
            SubmittedByDisplay.Text = "-";
            // 
            // DepartmentAcceptIssueBtn
            // 
            DepartmentAcceptIssueBtn.Font = new Font("Segoe UI", 7F);
            DepartmentAcceptIssueBtn.Location = new Point(411, 268);
            DepartmentAcceptIssueBtn.Name = "DepartmentAcceptIssueBtn";
            DepartmentAcceptIssueBtn.Size = new Size(70, 30);
            DepartmentAcceptIssueBtn.TabIndex = 20;
            DepartmentAcceptIssueBtn.Text = "Accept";
            DepartmentAcceptIssueBtn.UseVisualStyleBackColor = true;
            DepartmentAcceptIssueBtn.Click += DepartmentAcceptIssueBtn_Click;
            // 
            // DepartmentCompleteBtn
            // 
            DepartmentCompleteBtn.Font = new Font("Segoe UI", 6F);
            DepartmentCompleteBtn.Location = new Point(502, 268);
            DepartmentCompleteBtn.Name = "DepartmentCompleteBtn";
            DepartmentCompleteBtn.Size = new Size(70, 30);
            DepartmentCompleteBtn.TabIndex = 21;
            DepartmentCompleteBtn.Text = "Complete";
            DepartmentCompleteBtn.UseVisualStyleBackColor = true;
            DepartmentCompleteBtn.Click += DepartmentCompleteBtn_Click;
            // 
            // UserConfirmCompleteBtn
            // 
            UserConfirmCompleteBtn.Location = new Point(411, 264);
            UserConfirmCompleteBtn.Name = "UserConfirmCompleteBtn";
            UserConfirmCompleteBtn.Size = new Size(202, 33);
            UserConfirmCompleteBtn.TabIndex = 22;
            UserConfirmCompleteBtn.Text = "Confirm Complete";
            UserConfirmCompleteBtn.UseVisualStyleBackColor = true;
            UserConfirmCompleteBtn.Click += UserConfirmCompleteBtn_Click;
            // 
            // IssuePost
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(UserConfirmCompleteBtn);
            Controls.Add(DepartmentCompleteBtn);
            Controls.Add(DepartmentAcceptIssueBtn);
            Controls.Add(SubmittedByDisplay);
            Controls.Add(SubmittedByLabel);
            Controls.Add(RemovePostBtn);
            Controls.Add(CreateIssueTimeDisplay);
            Controls.Add(CreateIssuetimeLabel);
            Controls.Add(LocationDisplay);
            Controls.Add(DescriptionDisplay);
            Controls.Add(VoteCountDisplay);
            Controls.Add(StatusDisplay);
            Controls.Add(AgreeBtn);
            Controls.Add(StatusLabel);
            Controls.Add(LocationLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(PictureBox1);
            Font = new Font("Segoe UI", 9F);
            Name = "IssuePost";
            Size = new Size(628, 420);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PictureBox1;
        private Label DescriptionLabel;
        private Label LocationLabel;
        private Label StatusLabel;
        private Button AgreeBtn;
        private RichTextBox richTextBox1;
        private Label StatusDisplay;
        private Label VoteCountDisplay;
        private Label DescriptionDisplay;
        private Label LocationDisplay;
        private Label CreateIssuetimeLabel;
        private Label CreateIssueTimeDisplay;
        private Button RemovePostBtn;
        private Label SubmittedByLabel;
        private Label SubmittedByDisplay;
        private Button DepartmentAcceptIssueBtn;
        private Button DepartmentCompleteBtn;
        private Button UserConfirmCompleteBtn;
    }
}
