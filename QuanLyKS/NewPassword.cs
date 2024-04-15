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

            btnHideNewPassword.MouseDown += hidenpwBtn_MouseDown;
            btnHideNewPassword.MouseUp += hidenpwBtn_MouseUp;
            txbNewPassword.Enter += npwTb_Enter;
            txbNewPassword.Leave += npwTb_Leave;

            btnHideConfirmNewPassword.MouseDown += hidecnpwBtn_MouseDown;
            btnHideConfirmNewPassword.MouseUp += hidecnpwBtn_MouseUp;
            txbConfirmNewPassword.Enter += cnpwTb_Enter;
            txbConfirmNewPassword.Leave += cnpwTb_Leave;
        }

        private void npwTb_Enter(object sender, EventArgs e)
        {
            btnHideNewPassword.Visible = true;
        }

        private void npwTb_Leave(object sender, EventArgs e)
        {
            btnHideNewPassword.Visible = false;
        }

        private void hidenpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            btnHideNewPassword.Visible = false;
            viewnpwBtn.Visible = true;
            txbNewPassword.UseSystemPasswordChar = false;
            txbNewPassword.PasswordChar = '\0';
        }

        private void hidenpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHideNewPassword.Visible = true;
            viewnpwBtn.Visible = false;
            txbNewPassword.UseSystemPasswordChar = true;
        }

        private void cnpwTb_Enter(object sender, EventArgs e)
        {
            btnHideConfirmNewPassword.Visible = true;
        }

        private void cnpwTb_Leave(object sender, EventArgs e)
        {
            btnHideConfirmNewPassword.Visible = false;
        }

        private void hidecnpwBtn_MouseDown(object sender, MouseEventArgs e)
        {
            btnHideConfirmNewPassword.Visible = false;
            viewcnpwBtn.Visible = true;
            txbConfirmNewPassword.UseSystemPasswordChar = false;
            txbConfirmNewPassword.PasswordChar = '\0';
        }

        private void hidecnpwBtn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHideConfirmNewPassword.Visible = true;
            viewcnpwBtn.Visible = false;
            txbConfirmNewPassword.UseSystemPasswordChar = true;
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
