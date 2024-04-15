using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class LogIn : Form
    {
        private string username = "hovuanh";
        private string password = "3006";

        public LogIn()
        {
            InitializeComponent();
            loginBtn.Click += loginBtn_Click;
            hideBtn.MouseDown += hideBtn_MouseDown;
            hideBtn.MouseUp += hideBtn_MouseUp;
            passwordTb.Enter += passwordTb_Enter;
            passwordTb.Leave += passwordTb_Leave;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            warningIcon.Visible = false;
            usnblank.Visible = false;
            pwblank.Visible = false;
            invalidup.Visible = false;
            if (string.IsNullOrEmpty(usernameTb.Text))
            {
                warningIcon.Visible = true;
                usnblank.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(passwordTb.Text))
            {
                warningIcon.Visible = true;
                pwblank.Visible = true;
                return;
            }
            if (usernameTb.Text != username || passwordTb.Text!=password)
            {
                warningIcon.Visible = true;
                invalidup.Visible = true;
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void usernameTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passwordTb.Focus();
                passwordTb.SelectAll();
                e.Handled = true;
            }
        }

        private void passwordTb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                loginBtn.PerformClick();
                e.Handled = true;
            }
        }

        private void usernameTb_DoubleClick(object sender, EventArgs e)
        {
            usernameTb.SelectAll();
        }

        private void passwordTb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            passwordTb.SelectAll();
        }

        private void logupBt_Click(object sender, EventArgs e)
        {
            SignUp dangky = new SignUp();
            dangky.Show();
            this.Hide();
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            hideBtn.Visible = true;
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            hideBtn.Visible = false;
        }

        private void hideBtn_MouseDown(object sender, MouseEventArgs e)
        {
            hideBtn.Visible = false;
            viewBtn.Visible = true;
            passwordTb.UseSystemPasswordChar = false;
            passwordTb.PasswordChar = '\0';
        }
        
        private void hideBtn_MouseUp(object sender, MouseEventArgs e)
        {
            hideBtn.Visible = true;
            viewBtn.Visible = false;
            passwordTb.UseSystemPasswordChar = true;
        }

        private void forgotLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgottenPassword fp = new ForgottenPassword(this);
            fp.Show();
            this.Hide();
        }
    }
}
