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

            hidepwBtn.MouseDown += hidepwBtn_MouseDown;
            hidepwBtn.MouseUp += hidepwBtn_MouseUp;
            pwTb.Enter += pwTb_Enter;
            pwTb.Leave += pwTb_Leave;

            hidecpwBtn.MouseDown += hiderpwBtn_MouseDown;
            hidecpwBtn.MouseUp += hiderpwBtn_MouseUp;
            cpwTb.Enter += rpwTb_Enter;
            cpwTb.Leave += rpwTb_Leave;

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
            maleCheckbox.Checked = true;
            femaleCheckbox.Checked = false;
        }

        private void maleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckbox.Checked == true)
            {
                femaleCheckbox.Checked = false;
            }
        }

        private void femaleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckbox.Checked == true)
            {
                maleCheckbox.Checked = false;
            }
        }

        private void pwTb_Enter(object sender, EventArgs e)
        {
            hidepwBtn.Visible = true;
        }

        private void pwTb_Leave(object sender, EventArgs e)
        {
            hidepwBtn.Visible = false;
        }

        private void hidepwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            hidepwBtn.Visible = false;
            viewpwBtn.Visible = true;
            pwTb.UseSystemPasswordChar = false;
            pwTb.PasswordChar = '\0';
        }

        private void hidepwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            hidepwBtn.Visible = true;
            viewpwBtn.Visible = false;
            pwTb.UseSystemPasswordChar = true;
        }

        private void rpwTb_Enter(object sender, EventArgs e)
        {
            hidecpwBtn.Visible = true;
        }

        private void rpwTb_Leave(object sender, EventArgs e)
        {
            hidecpwBtn.Visible = false;
        }

        private void hiderpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            hidecpwBtn.Visible = false;
            viewcpwBtn.Visible = true;
            cpwTb.UseSystemPasswordChar = false;
            cpwTb.PasswordChar = '\0';
        }

        private void hiderpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            hidecpwBtn.Visible = true;
            viewcpwBtn.Visible = false;
            cpwTb.UseSystemPasswordChar = true;
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            ErrorProvider[] ePs = { FNeP, LNeP, UNeP, PWeP, CPWeP, MeP, RCeP, PeP };
            foreach (ErrorProvider ep in ePs)
            {
                ep.Clear();
            }

            if (string.IsNullOrEmpty(fnTb.Text))
            {
                FNeP.SetError(fnTb, "Please enter your firstname!");
            }
            else
            {
                FNeP.Clear();
            }



            if (string.IsNullOrEmpty(lnTb.Text))
            {
                LNeP.SetError(lnTb, "Please enter your lastname!");
            }
            else
            {
                LNeP.Clear();
            }



            if (string.IsNullOrEmpty(unTb.Text))
            {
                UNeP.SetError(unTb, "Please enter your username!");
            }
            else
            {
                UNeP.Clear();
            }



            if (string.IsNullOrEmpty(pwTb.Text))
            {
                PWeP.SetError(pwTb, "Please enter your password!");
            }
            else
            {
                PWeP.Clear();
            }



            if (string.IsNullOrEmpty(cpwTb.Text))
            {
                CPWeP.SetError(cpwTb, "Please confirm your password!");
            }
            else
            {
                CPWeP.Clear();
            }



            if (string.IsNullOrEmpty(mTb.Text))
            {
                MeP.SetError(mTb, "Please enter your mail!");
            }
            else
            {
                MeP.Clear();
            }



            if (string.IsNullOrEmpty(rcTb.Text))
            {
                RCeP.SetError(rcTb, "Please enter your registration code!");
            }
            else
            {
                RCeP.Clear();
            }



            if (string.IsNullOrEmpty(pTb.Text))
            {
                PeP.SetError(pTb, "Please enter your phone number!");
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
