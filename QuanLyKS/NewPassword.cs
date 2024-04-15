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
    public partial class NewPassword : Form
    {
        private Vertification vcF;
        public NewPassword(Vertification vc)
        {
            InitializeComponent();

            vcF = vc;

            hidenpwBtn.MouseDown += hidenpwBtn_MouseDown;
            hidenpwBtn.MouseUp += hidenpwBtn_MouseUp;
            npwTb.Enter += npwTb_Enter;
            npwTb.Leave += npwTb_Leave;

            hidecnpwBtn.MouseDown += hidecnpwBtn_MouseDown;
            hidecnpwBtn.MouseUp += hidecnpwBtn_MouseUp;
            cnpwTb.Enter += cnpwTb_Enter;
            cnpwTb.Leave += cnpwTb_Leave;
        }

        private void npwTb_Enter(object sender, EventArgs e)
        {
            hidenpwBtn.Visible = true;
        }

        private void npwTb_Leave(object sender, EventArgs e)
        {
            hidenpwBtn.Visible = false;
        }

        private void hidenpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            hidenpwBtn.Visible = false;
            viewnpwBtn.Visible = true;
            npwTb.UseSystemPasswordChar = false;
            npwTb.PasswordChar = '\0';
        }

        private void hidenpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            hidenpwBtn.Visible = true;
            viewnpwBtn.Visible = false;
            npwTb.UseSystemPasswordChar = true;
        }

        private void cnpwTb_Enter(object sender, EventArgs e)
        {
            hidecnpwBtn.Visible = true;
        }

        private void cnpwTb_Leave(object sender, EventArgs e)
        {
            hidecnpwBtn.Visible = false;
        }

        private void hidecnpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            hidecnpwBtn.Visible = false;
            viewcnpwBtn.Visible = true;
            cnpwTb.UseSystemPasswordChar = false;
            cnpwTb.PasswordChar = '\0';
        }

        private void hidecnpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            hidecnpwBtn.Visible = true;
            viewcnpwBtn.Visible = false;
            cnpwTb.UseSystemPasswordChar = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            vcF.Show();
            this.Hide();
        }
    }
}
