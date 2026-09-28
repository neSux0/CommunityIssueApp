namespace CommunityAppMiniProjectWinForms
{
    partial class CreateAccountForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateAccountTitle = new Label();
            UserNameLabelCreation = new Label();
            CreateAccountSubtitle = new Label();
            PasswordLabelCreation = new Label();
            UsernamePanel2 = new Panel();
            UserNameLabel2 = new Label();
            UserNameTextBox2 = new TextBox();
            PasswordPanel2 = new Panel();
            PasswordLabel2 = new Label();
            PasswordTextbox2 = new TextBox();
            SignUpBtn = new Button();
            IsGov = new CheckBox();
            UsernamePanel2.SuspendLayout();
            PasswordPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // CreateAccountTitle
            // 
            CreateAccountTitle.AutoSize = true;
            CreateAccountTitle.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            CreateAccountTitle.ForeColor = Color.Firebrick;
            CreateAccountTitle.Location = new Point(158, 53);
            CreateAccountTitle.Name = "CreateAccountTitle";
            CreateAccountTitle.Size = new Size(498, 46);
            CreateAccountTitle.TabIndex = 0;
            CreateAccountTitle.Text = "Get started on The Community";
            // 
            // UserNameLabelCreation
            // 
            UserNameLabelCreation.AutoSize = true;
            UserNameLabelCreation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            UserNameLabelCreation.Location = new Point(158, 186);
            UserNameLabelCreation.Name = "UserNameLabelCreation";
            UserNameLabelCreation.Size = new Size(106, 28);
            UserNameLabelCreation.TabIndex = 1;
            UserNameLabelCreation.Text = "Username";
            // 
            // CreateAccountSubtitle
            // 
            CreateAccountSubtitle.AutoSize = true;
            CreateAccountSubtitle.Location = new Point(181, 116);
            CreateAccountSubtitle.Name = "CreateAccountSubtitle";
            CreateAccountSubtitle.Size = new Size(399, 25);
            CreateAccountSubtitle.TabIndex = 2;
            CreateAccountSubtitle.Text = "Sign up to make a difference in your community.";
            // 
            // PasswordLabelCreation
            // 
            PasswordLabelCreation.AutoSize = true;
            PasswordLabelCreation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            PasswordLabelCreation.Location = new Point(163, 255);
            PasswordLabelCreation.Name = "PasswordLabelCreation";
            PasswordLabelCreation.Size = new Size(101, 28);
            PasswordLabelCreation.TabIndex = 3;
            PasswordLabelCreation.Text = "Password";
            // 
            // UsernamePanel2
            // 
            UsernamePanel2.BorderStyle = BorderStyle.FixedSingle;
            UsernamePanel2.Controls.Add(UserNameLabel2);
            UsernamePanel2.Controls.Add(UserNameTextBox2);
            UsernamePanel2.Cursor = Cursors.IBeam;
            UsernamePanel2.Location = new Point(272, 174);
            UsernamePanel2.Name = "UsernamePanel2";
            UsernamePanel2.Size = new Size(280, 47);
            UsernamePanel2.TabIndex = 7;
            // 
            // UserNameLabel2
            // 
            UserNameLabel2.AutoSize = true;
            UserNameLabel2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserNameLabel2.ForeColor = SystemColors.ButtonShadow;
            UserNameLabel2.Location = new Point(3, 3);
            UserNameLabel2.Name = "UserNameLabel2";
            UserNameLabel2.Size = new Size(142, 38);
            UserNameLabel2.TabIndex = 1;
            UserNameLabel2.Text = "Username";
            UserNameLabel2.Click += UserNameLabel2_Click;
            // 
            // UserNameTextBox2
            // 
            UserNameTextBox2.BorderStyle = BorderStyle.None;
            UserNameTextBox2.Cursor = Cursors.IBeam;
            UserNameTextBox2.Location = new Point(3, 14);
            UserNameTextBox2.Name = "UserNameTextBox2";
            UserNameTextBox2.Size = new Size(276, 24);
            UserNameTextBox2.TabIndex = 2;
            UserNameTextBox2.Leave += UserNameTextBox2_Leave;
            // 
            // PasswordPanel2
            // 
            PasswordPanel2.BorderStyle = BorderStyle.FixedSingle;
            PasswordPanel2.Controls.Add(PasswordLabel2);
            PasswordPanel2.Controls.Add(PasswordTextbox2);
            PasswordPanel2.Cursor = Cursors.IBeam;
            PasswordPanel2.Location = new Point(272, 246);
            PasswordPanel2.Name = "PasswordPanel2";
            PasswordPanel2.Size = new Size(280, 47);
            PasswordPanel2.TabIndex = 8;
            // 
            // PasswordLabel2
            // 
            PasswordLabel2.AutoSize = true;
            PasswordLabel2.Font = new Font("Segoe UI", 14F);
            PasswordLabel2.ForeColor = SystemColors.ButtonShadow;
            PasswordLabel2.Location = new Point(3, 0);
            PasswordLabel2.Name = "PasswordLabel2";
            PasswordLabel2.Size = new Size(132, 38);
            PasswordLabel2.TabIndex = 2;
            PasswordLabel2.Text = "Password";
            PasswordLabel2.Click += PasswordLabel2_Click;
            // 
            // PasswordTextbox2
            // 
            PasswordTextbox2.BorderStyle = BorderStyle.None;
            PasswordTextbox2.Location = new Point(3, 20);
            PasswordTextbox2.Name = "PasswordTextbox2";
            PasswordTextbox2.Size = new Size(272, 24);
            PasswordTextbox2.TabIndex = 4;
            PasswordTextbox2.UseSystemPasswordChar = true;
            PasswordTextbox2.Leave += PasswordTextbox2_Leave;
            // 
            // SignUpBtn
            // 
            SignUpBtn.Location = new Point(328, 369);
            SignUpBtn.Name = "SignUpBtn";
            SignUpBtn.Size = new Size(112, 34);
            SignUpBtn.TabIndex = 9;
            SignUpBtn.Text = "Submit";
            SignUpBtn.UseVisualStyleBackColor = true;
            SignUpBtn.Click += SignUpBtn_Click;
            // 
            // IsGov
            // 
            IsGov.AutoSize = true;
            IsGov.Location = new Point(158, 312);
            IsGov.Name = "IsGov";
            IsGov.Size = new Size(467, 29);
            IsGov.TabIndex = 10;
            IsGov.Text = "Check the box if you are a state department employee";
            IsGov.UseVisualStyleBackColor = true;
            // 
            // CreateAccountForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(IsGov);
            Controls.Add(SignUpBtn);
            Controls.Add(PasswordPanel2);
            Controls.Add(UsernamePanel2);
            Controls.Add(PasswordLabelCreation);
            Controls.Add(CreateAccountSubtitle);
            Controls.Add(UserNameLabelCreation);
            Controls.Add(CreateAccountTitle);
            Name = "CreateAccountForm";
            Text = "Create An Account";
            UsernamePanel2.ResumeLayout(false);
            UsernamePanel2.PerformLayout();
            PasswordPanel2.ResumeLayout(false);
            PasswordPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreateAccountTitle;
        private Label UserNameLabelCreation;
        private Label CreateAccountSubtitle;
        private Label PasswordLabelCreation;
        private Panel UsernamePanel2;
        private Label UserNameLabel2;
        private TextBox UserNameTextBox2;
        private Panel PasswordPanel2;
        private Label PasswordLabel2;
        private TextBox PasswordTextbox2;
        private Button SignUpBtn;
        private CheckBox IsGov;
    }
}