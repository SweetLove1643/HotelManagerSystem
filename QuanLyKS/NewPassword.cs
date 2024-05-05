using QuanLyKS.ClassFuncion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class NewPassword : Form
    {
        private Vertification vcF;
        private string mail = "";
        public NewPassword(Vertification vc)
        {
            InitializeComponent();

            vcF = vc;
            mail = vc.mail;

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
            try
            {
                if (IsValidPassword(txbNewPassword.Text))
                {
                    if (txbNewPassword.Text.Equals(txbConfirmNewPassword.Text))
                    {
                        string hasspass = Hashing.Instance.Hash384(txbNewPassword.Text);
                        if(DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.ChangePassword @Email , @Newpassword ", new object[] {mail, hasspass}) != 0)
                        {
                            MessageBox.Show("Thay đổi mật khẩu thành công", "Messages", MessageBoxButtons.OK);
                            LogIn logIn = new LogIn();
                            logIn.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu chưa đúng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhật mật khẩu tối thiểu 8 kí tự, có chữ kí tự hoa, thường và đặc biệt ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            vcF.Show();
            this.Hide();
        }
        private bool IsValidPassword(string password)
        {
            try
            {
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
                return Regex.IsMatch(password, pattern);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }// Kiểm tra mức độ phức tạp của password
    }
}
