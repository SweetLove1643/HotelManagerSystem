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
        public Vertification(ForgottenPassword fp)
        {
            InitializeComponent();
            fpF = fp;
            if(fp != null)
            {
                string mail = fp.txbMail.Text;
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
            if(string.IsNullOrEmpty(txbOTP.Text))
            {
                vcPb.Visible = true;
                invalidInfoTT.SetToolTip(vcPb, "Please enter the vertification code!");
            }
            else
            {
                vcPb.Visible = false;
                NewPassword np = new NewPassword(this);
                np.Show();
                this.Hide();
            }
        }
    }
}
