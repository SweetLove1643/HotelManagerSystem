using QuanLyKS.ClassFuncion;
using QuanLyKS.ClassObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace QuanLyKS.Resources
{
    public partial class EmployeeInfoUC : UserControl
    {
        private string idnv;
        private string username;
        public string Idnv { get => idnv; set => idnv = value; }
        public string Username { get => username; set => username = value; }

        public EmployeeInfoUC(string Username)
        {
            InitializeComponent();
            this.Username = Username;
            DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDNV FROM dbo.NhanVien WHERE SDT = '{Username}' OR Mail = '{Username}'");
            if (data != null)
            {
                this.Idnv = data.Rows[0]["IDNV"].ToString();
            }
            LoadFormUCInfo();
        }
        public void LoadFormUCInfo()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT * FROM dbo.NhanVien WHERE (SDT = '{Username}' OR Mail = '{Username}')");
                if (data.Rows.Count > 0)
                {
                    PersonnelObject pr = new PersonnelObject(data.Rows[0]);
                    txbManhanvien.Text = pr.Idnv.ToString();
                    txbName.Text = pr.Name.ToString();
                    txbPhone.Text = pr.Phone.ToString();
                    txbCCCD.Text = pr.Cccd.ToString();
                    txbMail.Text = pr.Mail.ToString();
                    txbPosition.Text = pr.Position.ToString();
                    DateOfBirth.Value = pr.Dateofbrith;
                    string sex = pr.Sex.ToString();
                    if (sex.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                        ChbMale.Checked = true;
                    else if (sex.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                        ChbFemale.Checked = true;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbMale.Checked)
            {
                ChbFemale.Checked = false;
            }
        }

        private void ChbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbFemale.Checked)
            {
                ChbMale.Checked = false;
            }
        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidPhoneNumber(txbPhone.Text))
                {
                    if (IsValidEmail(txbMail.Text))
                    {
                        btnupdate.Visible = true;
                        btncomfirm.Visible = false;

                        string sex = "Nam";
                        if (ChbFemale.Checked == true)
                            sex = "Nữ";
                        if (DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.Update_Info_NhanVien @IDNV , @Name , @Sex , @Dateofbirth , @Phone , @CCCD , @Mail ", new object[] { txbManhanvien.Text, txbName.Text, sex, DateOfBirth.Value.ToString("yyyy/MM/dd"), txbPhone.Text, txbCCCD.Text, txbMail.Text }) != 0)
                        {
                            MessageBox.Show("Cập nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhập thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnupdate.Visible = false;
                btncomfirm.Visible = true;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangepass_Click(object sender, EventArgs e)
        {
            try
            {
                string hassoldpass = Hashing.Instance.Hash384(txbOldpass.Text);
                string hassnewpass = Hashing.Instance.Hash384(txbNewpass.Text);
                if (DataProvider.Instance.ExecuteQuerry($"SELECT 1 from dbo.TaiKhoan WHERE (Mail = '{Username}' OR SDT = '{Username}') AND MatKhau = N'{hassoldpass}'").Rows.Count > 0)
                {
                    if (txbComfirmnewpass.Text == txbNewpass.Text)
                    {
                        if (IsValidPassword(txbNewpass.Text) == true)
                        {
                            DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.TaiKhoan SET MatKhau = N'{hassnewpass}' WHERE (Mail = '{Username}' OR SDT = '{Username}')");
                            MessageBox.Show("Đổi mật khẩu thành công.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                            MessageBox.Show("Vui lòng nhập mật khẩu có 8 kí tự, hoa và thường và kí tự đặc biệt.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Nhập lại mật khẩu chưa đúng .", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        }
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

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
