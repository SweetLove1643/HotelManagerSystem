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
            btnLogin.Click += loginBtn_Click;
            btnHidePass.MouseDown += hideBtn_MouseDown;
            btnHidePass.MouseUp += hideBtn_MouseUp;
            txbPassword.Enter += passwordTb_Enter;
            txbPassword.Leave += passwordTb_Leave;
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
            if (string.IsNullOrEmpty(txbUsername.Text))
            {
                warningIcon.Visible = true;
                usnblank.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(txbPassword.Text))
            {
                warningIcon.Visible = true;
                pwblank.Visible = true;
                return;
            }
            if (txbUsername.Text != username || txbPassword.Text!=password)
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
                txbPassword.Focus();
                txbPassword.SelectAll();
                e.Handled = true;
            }
        }

        private void passwordTb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
            }
        }

        private void usernameTb_DoubleClick(object sender, EventArgs e)
        {
            txbUsername.SelectAll();
        }

        private void passwordTb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txbPassword.SelectAll();
        }

        private void logupBt_Click(object sender, EventArgs e)
        {
            SignUp dangky = new SignUp();
            this.Hide();
            dangky.ShowDialog();
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            btnHidePass.Visible = true;
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            btnHidePass.Visible = false;
        }

        private void hideBtn_MouseDown(object sender, MouseEventArgs e)
        {
            btnHidePass.Visible = false;
            viewBtn.Visible = true;
            txbPassword.UseSystemPasswordChar = false;
            txbPassword.PasswordChar = '\0';
        }
        
        private void hideBtn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHidePass.Visible = true;
            viewBtn.Visible = false;
            txbPassword.UseSystemPasswordChar = true;
        }

        private void forgotLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgottenPassword fp = new ForgottenPassword(this);
            fp.Show();
            this.Hide();
        }
    }
}
