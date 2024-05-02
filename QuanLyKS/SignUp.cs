using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyKS
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();


            btnHidePass.MouseDown += hidepwBtn_MouseDown;
            btnHidePass.MouseUp += hidepwBtn_MouseUp;
            txbPassWord.Enter += pwTb_Enter;
            txbPassWord.Leave += pwTb_Leave;

            btnHideConfirmPass.MouseDown += hiderpwBtn_MouseDown;
            btnHideConfirmPass.MouseUp += hiderpwBtn_MouseUp;
            txbConfirmPassword.Enter += rpwTb_Enter;
            txbConfirmPassword.Leave += rpwTb_Leave;

            viewpwBtn.Visible = false;
        }

        private void Logup_Load(object sender, EventArgs e)
        {
            ChbMale.Checked = true;
            ChbFemale.Checked = false;
        }

        private void maleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbMale.Checked == true)
            {
                ChbFemale.Checked = false;
            }
        }

        private void femaleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbFemale.Checked == true)
            {
                ChbMale.Checked = false;
            }
        }

        private void pwTb_Enter(object sender, EventArgs e)
        {
            btnHidePass.Visible = true;
        }

        private void pwTb_Leave(object sender, EventArgs e)
        {
            btnHidePass.Visible = false;
        }

        private void hidepwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            btnHidePass.Visible = false;
            viewpwBtn.Visible = true;
            txbPassWord.UseSystemPasswordChar = false;
            txbPassWord.PasswordChar = '\0';
        }

        private void hidepwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHidePass.Visible = true;
            viewpwBtn.Visible = false;
            txbPassWord.UseSystemPasswordChar = true;
        }

        private void rpwTb_Enter(object sender, EventArgs e)
        {
            btnHideConfirmPass.Visible = true;
        }

        private void rpwTb_Leave(object sender, EventArgs e)
        {
            btnHideConfirmPass.Visible = false;
        }

        private void hiderpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            btnHideConfirmPass.Visible = false;
            viewcpwBtn.Visible = true;
            txbConfirmPassword.UseSystemPasswordChar = false;
            txbConfirmPassword.PasswordChar = '\0';
        }

        private void hiderpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHideConfirmPass.Visible = true;
            viewcpwBtn.Visible = false;
            txbConfirmPassword.UseSystemPasswordChar = true;
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbFistName.Text))
            {
                fnPb.Visible = true;
                invalidInfoTT.SetToolTip(fnPb, "Please enter your firstname!");
            }
            else
            {
                fnPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbLastName.Text))
            {
                lnPb.Visible = true;
                invalidInfoTT.SetToolTip(lnPb, "Please enter your lastname!");
            }
            else
            {
                lnPb.Visible = false;
            }

            if(string.IsNullOrEmpty(txbRegistration.Text))
            {
                rcPb.Visible = true;
                invalidInfoTT.SetToolTip(rcPb, "Please enter your registration code!");
            }
            else
            {
                rcPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbUserName.Text))
            {
                unPb.Visible = true;
                invalidInfoTT.SetToolTip(unPb, "Please enter your username!");
            }
            else
            {
                unPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbPassWord.Text))
            {
                pwPb.Visible = true;
                invalidInfoTT.SetToolTip(pwPb, "Please enter your password!");
            }
            else
            {
                pwPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbConfirmPassword.Text))
            {
                cpwPb.Visible = true;
                invalidInfoTT.SetToolTip(cpwPb, "Please confirm your password!");
            }
            else
            {
                cpwPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbMail.Text))
            {
                mPb.Visible = true;
                invalidInfoTT.SetToolTip(mPb, "Please enter your mail!");
            }
            else
            {
                mPb.Visible = false;
            }

            if (string.IsNullOrEmpty(txbPhone.Text))
            {
                pPb.Visible = true;
                invalidInfoTT.SetToolTip(pPb, "Please enter your phonenumber!");
            }
            else
            {
                pPb.Visible = false;
            }
        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            LogIn dangnhap = new LogIn();
            dangnhap.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
