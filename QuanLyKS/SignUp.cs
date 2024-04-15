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

            FNeP = new ErrorProvider();
            LNeP = new ErrorProvider();
            UNeP = new ErrorProvider();
            PWeP = new ErrorProvider();
            CPWeP = new ErrorProvider();
            MeP = new ErrorProvider();
            RCeP = new ErrorProvider();
            PeP = new ErrorProvider();

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

        public void RunCheckDataValid(bool flag, ErrorProvider eP, Control c, string e)
        {
            if(flag==false)
            {
                c.Focus();
                eP.SetError(c, e);
            }
            else
            {
                eP.SetError(c, null);
            }
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
            ErrorProvider[] ePs = { FNeP, LNeP, UNeP, PWeP, CPWeP, MeP, RCeP, PeP };
            foreach (ErrorProvider ep in ePs)
            {
                ep.Clear();
            }

            if (string.IsNullOrEmpty(txbFistName.Text))
            {
                FNeP.SetError(txbFistName, "Please enter your firstname!");
            }
            else
            {
                FNeP.Clear();
            }



            if (string.IsNullOrEmpty(txbLastName.Text))
            {
                LNeP.SetError(txbLastName, "Please enter your lastname!");
            }
            else
            {
                LNeP.Clear();
            }



            if (string.IsNullOrEmpty(txbUserName.Text))
            {
                UNeP.SetError(txbUserName, "Please enter your username!");
            }
            else
            {
                UNeP.Clear();
            }



            if (string.IsNullOrEmpty(txbPassWord.Text))
            {
                PWeP.SetError(txbPassWord, "Please enter your password!");
            }
            else
            {
                PWeP.Clear();
            }



            if (string.IsNullOrEmpty(txbConfirmPassword.Text))
            {
                CPWeP.SetError(txbConfirmPassword, "Please confirm your password!");
            }
            else
            {
                CPWeP.Clear();
            }



            if (string.IsNullOrEmpty(txbMail.Text))
            {
                MeP.SetError(txbMail, "Please enter your mail!");
            }
            else
            {
                MeP.Clear();
            }



            if (string.IsNullOrEmpty(txbRegistration.Text))
            {
                RCeP.SetError(txbRegistration, "Please enter your registration code!");
            }
            else
            {
                RCeP.Clear();
            }



            if (string.IsNullOrEmpty(txbPhone.Text))
            {
                PeP.SetError(txbPhone, "Please enter your phone number!");
            }
            else
            {
                PeP.Clear();
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
