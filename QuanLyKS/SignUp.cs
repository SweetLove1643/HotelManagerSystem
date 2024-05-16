using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyKS.ClassFuncion;

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
            try
            {
                if (Checkbox() == true)// Nếu mọi thứ nhập vào ok thì...
                {
                    string hashpassword = Hashing.Instance.Hash384(txbPassWord.Text);
                    string sex = "";
                    if (ChbMale.Checked)
                        sex = "Nam";
                    else
                        sex = "Nữ";
                    DateTime dateofbirth = DateOfBirth.Value;
                    DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateNewAccount @SDT , @Mail , @Password , @Accounttype ", new object[] { txbPhone.Text, txbMail.Text, hashpassword, "Khách hàng" });
                    DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateNewGuest @Guestname , @Sex , @DateOfBrith , @CCCD , @Nationality , @Phone , @Mail " , new object[] { txbFistName.Text + txbLastName.Text, sex, dateofbirth.ToString("yyyy/MM/dd"), txbRegistration.Text, txbNationality.Text , txbPhone.Text, txbMail.Text });
                    MessageBox.Show("Tạo tài khoản thành công.", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    LogIn logIn = new LogIn();
                    logIn.Show();
                    this.Hide();
                }
                #region
                if (string.IsNullOrEmpty(txbFistName.Text))
                {
                    fnPb.Visible = true;
                    invalidInfoTT.SetToolTip(fnPb, "Vui lòng nhập họ của bạn!");
                }
                else
                {
                    fnPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbLastName.Text))
                {
                    lnPb.Visible = true;
                    invalidInfoTT.SetToolTip(lnPb, "Vui lòng nhập tên của bạn!");
                }
                else
                {
                    lnPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbRegistration.Text))
                {
                    rcPb.Visible = true;
                    invalidInfoTT.SetToolTip(rcPb, "Vui lòng nhập mã CCCD của bạn!");
                }
                else
                {
                    rcPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbNationality.Text))
                {
                    unPb.Visible = true;
                    invalidInfoTT.SetToolTip(unPb, "Vui lòng nhập quốc tịch của bạn!");
                }
                else
                {
                    unPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbPassWord.Text))
                {
                    pwPb.Visible = true;
                    invalidInfoTT.SetToolTip(pwPb, "Vui lòng nhập mật khẩu của bạn!");
                }
                else
                {
                    pwPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbConfirmPassword.Text))
                {
                    cpwPb.Visible = true;
                    invalidInfoTT.SetToolTip(cpwPb, "Vui lòng xác nhận lại mật khẩu của bạn!");
                }
                else
                {
                    cpwPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbMail.Text))
                {
                    mPb.Visible = true;
                    invalidInfoTT.SetToolTip(mPb, "Vui lòng nhập mail của bạn!");
                }
                else
                {
                    mPb.Visible = false;
                }

                if (string.IsNullOrEmpty(txbPhone.Text))
                {
                    pPb.Visible = true;
                    invalidInfoTT.SetToolTip(pPb, "Vui lòng nhập số điện thoại của bạn!");
                }
                else
                {
                    pPb.Visible = false;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    /*pPb.Visible = true;
                    invalidInfoTT.SetToolTip(pPb, "Số điện thoại hoặc email đã tồn tại. Vui lòng nhập lại.");*/
                    MessageBox.Show("Số điện thoại hoặc email đã tồn tại. Vui lòng nhập lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Checkbox()
        {
            if (string.IsNullOrEmpty(txbFistName.Text))
                return false;
            if (string.IsNullOrEmpty(txbLastName.Text))
                return false;
            if (string.IsNullOrEmpty(txbNationality.Text))
                return false;
            if (string.IsNullOrEmpty(txbPassWord.Text))
                return false;
            else
            {
                if (IsValidPassword(txbPassWord.Text) == false)
                {
                    /*pwPb.Visible = true;
                    invalidInfoTT.SetToolTip(pwPb, "Vui lòng nhật mật khẩu tối thiểu 8 kí tự, có chữ kí tự hoa, thường và đặc biệt!");*/
                    MessageBox.Show("Vui lòng nhật mật khẩu tối thiểu 8 kí tự, có chữ kí tự hoa, thường và đặc biệt ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txbConfirmPassword.Text))
                return false;
            else
            {
                if (txbConfirmPassword.Text != txbPassWord.Text)
                {
                    /*cpwPb.Visible = true;
                    invalidInfoTT.SetToolTip(cpwPb, "Nhập lại mật khẩu chưa đúng. Vui lòng nhập lại.");*/
                    MessageBox.Show("Nhập lại mật khẩu chưa đúng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txbMail.Text))
                return false;
            else
            {
                if (IsValidEmail(txbMail.Text) == false)
                {
                    /*mPb.Visible = true;
                    invalidInfoTT.SetToolTip(mPb, "Email chưa đúng định dạng. Vui lòng nhập lại.");*/
                    MessageBox.Show("Email chưa đúng định dạng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txbPhone.Text))
                return false;
            else
            {
                if (IsValidPhoneNumber(txbPhone.Text) == false)
                {
                    /*pPb.Visible = true;
                    invalidInfoTT.SetToolTip(pPb, "Số điện thoại chưa đúng định dạng. Vui lòng nhập lại.");*/
                    MessageBox.Show("Số điện thoại chưa đúng định dạng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txbRegistration.Text))
                return false;
            return true;
        }// Kiểm tra thông tin đầu vào
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }// Kiểm tra định dạng Email
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
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            try
            {
                string pattern = @"^(?:(?:\+|0{0,2})84|0)?[1-9]\d{8}$";
                return Regex.IsMatch(phoneNumber, pattern);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }// Kiểm tra định dạng số điện thoại

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
