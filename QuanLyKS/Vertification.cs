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
    public partial class Vertification : Form
    {
        private ForgottenPassword fpF;
        private string otp = "";
        public string mail = "";
        public Vertification(ForgottenPassword fp, string otp)
        {
            InitializeComponent();
            fpF = fp;
            this.otp = otp;
            if (fp != null)
            {
                mail = fp.txbMail.Text;
                noteLb.Text = $"We have just sent the vertification code to <span style=\" color: black; text-decoration: underline;\">{mail}</span>. Please check your mail and enter the vertification code.";
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            fpF.Show();
            this.Hide();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbOTP.Text))
                {
                    vcPb.Visible = true;
                    invalidInfoTT.SetToolTip(vcPb, "Please enter the vertification code!");
                }
                else
                {
                    vcPb.Visible = false;
                    if (otp.Equals(txbOTP.Text))
                    {
                        NewPassword fnp = new NewPassword(this);
                        fnp.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Mã OTP không đúng, vui lòng nhập lại!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txbOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
