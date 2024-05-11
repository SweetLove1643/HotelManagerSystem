using QuanLyKS.ClassFuncion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
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
                if ((DataProvider.Instance.ExecuteQuerry("EXEC CheckAccountAndPassword @username , @password ", new object[] { txbUsername.Text, Hashing.Instance.Hash384(txbPassword.Text) })).Rows.Count == 0)
            {
                warningIcon.Visible = true;
                invalidup.Visible = true;
                return;
            }
            else
            {
                    int temp = (int)DataProvider.Instance.ExecuteScalar("SELECT dbo.CheckAccount( @username , @password )", new object[] { txbUsername.Text, Hashing.Instance.Hash384(txbPassword.Text) });
                    switch (temp)
                    {
                        case 1:
                            {
                            Admin ad = new Admin(txbUsername.Text);
                            this.Hide();
                            ad.ShowDialog();
                            break;
                            }
                        case 0:
                            {
                            Employee emp = new Employee(txbUsername.Text);
                            this.Hide();
                            emp.ShowDialog();
                            break;
                            }
                        default:
                            {
                            User us = new User(txbUsername.Text);
                            this.Hide();
                            us.ShowDialog();
                            break;
                    }
                }
            }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
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
            if (e.KeyCode == Keys.Enter)
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
