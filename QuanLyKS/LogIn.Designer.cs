
namespace QuanLyKS
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.warningIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.invalidup = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnForgetPass = new System.Windows.Forms.LinkLabel();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.usnblank = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pwblank = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.viewBtn = new Guna.UI2.WinForms.Guna2Button();
            this.btnHidePass = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::QuanLyKS.Properties.Resources.Screenshot_2024_04_05_133734;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(250, 20);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(215, 135);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Location = new System.Drawing.Point(110, 245);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(470, 1);
            this.guna2Panel1.TabIndex = 3;
            // 
            // txbUsername
            // 
            this.txbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbUsername.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txbUsername.BorderThickness = 0;
            this.txbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUsername.DefaultText = "";
            this.txbUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbUsername.ForeColor = System.Drawing.Color.Black;
            this.txbUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("txbUsername.IconLeft")));
            this.txbUsername.Location = new System.Drawing.Point(110, 195);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.PasswordChar = '\0';
            this.txbUsername.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txbUsername.PlaceholderText = "Email / số điện thoại";
            this.txbUsername.SelectedText = "";
            this.txbUsername.Size = new System.Drawing.Size(470, 50);
            this.txbUsername.TabIndex = 4;
            this.txbUsername.DoubleClick += new System.EventHandler(this.usernameTb_DoubleClick);
            this.txbUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTb_KeyDown);
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txbPassword.BorderThickness = 0;
            this.txbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPassword.DefaultText = "";
            this.txbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.txbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbPassword.ForeColor = System.Drawing.Color.Black;
            this.txbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("txbPassword.IconLeft")));
            this.txbPassword.Location = new System.Drawing.Point(110, 265);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '●';
            this.txbPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txbPassword.PlaceholderText = "Password";
            this.txbPassword.SelectedText = "";
            this.txbPassword.Size = new System.Drawing.Size(470, 50);
            this.txbPassword.TabIndex = 5;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.Enter += new System.EventHandler(this.passwordTb_Enter);
            this.txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTb_KeyDown);
            this.txbPassword.Leave += new System.EventHandler(this.passwordTb_Leave);
            this.txbPassword.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.passwordTb_MouseDoubleClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Location = new System.Drawing.Point(110, 315);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(470, 1);
            this.guna2Panel2.TabIndex = 6;
            // 
            // warningIcon
            // 
            this.warningIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.warningIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.warningIcon.Image = ((System.Drawing.Image)(resources.GetObject("warningIcon.Image")));
            this.warningIcon.ImageRotate = 0F;
            this.warningIcon.Location = new System.Drawing.Point(110, 328);
            this.warningIcon.Name = "warningIcon";
            this.warningIcon.Size = new System.Drawing.Size(25, 20);
            this.warningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.warningIcon.TabIndex = 8;
            this.warningIcon.TabStop = false;
            this.warningIcon.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.BorderThickness = 1;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.LightCoral;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(270, 380);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 45);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Log in";
            this.btnLogin.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageSize = new System.Drawing.Size(30, 30);
            this.btnExit.Location = new System.Drawing.Point(640, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 40);
            this.btnExit.TabIndex = 11;
            this.btnExit.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // invalidup
            // 
            this.invalidup.AutoSize = false;
            this.invalidup.BackColor = System.Drawing.Color.Transparent;
            this.invalidup.ForeColor = System.Drawing.Color.Crimson;
            this.invalidup.Location = new System.Drawing.Point(140, 330);
            this.invalidup.Name = "invalidup";
            this.invalidup.Size = new System.Drawing.Size(190, 20);
            this.invalidup.TabIndex = 12;
            this.invalidup.Text = "Invalid username or password";
            this.invalidup.Visible = false;
            // 
            // btnForgetPass
            // 
            this.btnForgetPass.AutoSize = true;
            this.btnForgetPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnForgetPass.ForeColor = System.Drawing.Color.Gray;
            this.btnForgetPass.LinkColor = System.Drawing.Color.Gray;
            this.btnForgetPass.Location = new System.Drawing.Point(435, 326);
            this.btnForgetPass.Name = "btnForgetPass";
            this.btnForgetPass.Size = new System.Drawing.Size(153, 17);
            this.btnForgetPass.TabIndex = 10;
            this.btnForgetPass.TabStop = true;
            this.btnForgetPass.Text = "Forgot your password?";
            this.btnForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotLink_LinkClicked);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnSignUp.BorderRadius = 5;
            this.btnSignUp.BorderThickness = 1;
            this.btnSignUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSignUp.ForeColor = System.Drawing.Color.Black;
            this.btnSignUp.Location = new System.Drawing.Point(270, 445);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(180, 26);
            this.btnSignUp.TabIndex = 13;
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.Click += new System.EventHandler(this.logupBt_Click);
            // 
            // usnblank
            // 
            this.usnblank.AutoSize = false;
            this.usnblank.BackColor = System.Drawing.Color.Transparent;
            this.usnblank.ForeColor = System.Drawing.Color.Crimson;
            this.usnblank.Location = new System.Drawing.Point(140, 330);
            this.usnblank.Name = "usnblank";
            this.usnblank.Size = new System.Drawing.Size(190, 20);
            this.usnblank.TabIndex = 14;
            this.usnblank.Text = "Please enter your username";
            this.usnblank.Visible = false;
            // 
            // pwblank
            // 
            this.pwblank.AutoSize = false;
            this.pwblank.BackColor = System.Drawing.Color.Transparent;
            this.pwblank.ForeColor = System.Drawing.Color.Crimson;
            this.pwblank.Location = new System.Drawing.Point(140, 330);
            this.pwblank.Name = "pwblank";
            this.pwblank.Size = new System.Drawing.Size(190, 20);
            this.pwblank.TabIndex = 15;
            this.pwblank.Text = "Please enter your password";
            this.pwblank.Visible = false;
            // 
            // viewBtn
            // 
            this.viewBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.HoverState.BorderColor = System.Drawing.Color.Black;
            this.viewBtn.HoverState.CustomBorderColor = System.Drawing.Color.Black;
            this.viewBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.viewBtn.HoverState.ForeColor = System.Drawing.Color.Black;
            this.viewBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewBtn.Image")));
            this.viewBtn.Location = new System.Drawing.Point(550, 278);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.viewBtn.Size = new System.Drawing.Size(30, 20);
            this.viewBtn.TabIndex = 16;
            this.viewBtn.Visible = false;
            // 
            // btnHidePass
            // 
            this.btnHidePass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHidePass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHidePass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHidePass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHidePass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnHidePass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHidePass.ForeColor = System.Drawing.Color.White;
            this.btnHidePass.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnHidePass.Image = ((System.Drawing.Image)(resources.GetObject("btnHidePass.Image")));
            this.btnHidePass.Location = new System.Drawing.Point(550, 278);
            this.btnHidePass.Name = "btnHidePass";
            this.btnHidePass.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnHidePass.Size = new System.Drawing.Size(30, 20);
            this.btnHidePass.TabIndex = 17;
            this.btnHidePass.Visible = false;
            this.btnHidePass.Click += new System.EventHandler(this.btnHidePass_Click);
            this.btnHidePass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hideBtn_MouseDown);
            this.btnHidePass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hideBtn_MouseUp);
            // 
            // LogIn
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::QuanLyKS.Properties.Resources.Screenshot_2024_04_05_133738;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.btnHidePass);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.pwblank);
            this.Controls.Add(this.usnblank);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnForgetPass);
            this.Controls.Add(this.invalidup);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.warningIcon);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txbUsername;
        private Guna.UI2.WinForms.Guna2TextBox txbPassword;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox warningIcon;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2HtmlLabel invalidup;
        private System.Windows.Forms.LinkLabel btnForgetPass;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
        private Guna.UI2.WinForms.Guna2HtmlLabel usnblank;
        private Guna.UI2.WinForms.Guna2HtmlLabel pwblank;
        private Guna.UI2.WinForms.Guna2Button viewBtn;
        private Guna.UI2.WinForms.Guna2Button btnHidePass;
    }
}

