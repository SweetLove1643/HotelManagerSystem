using QuanLyKS.ClassFuncion;
using QuanLyKS.ClassObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class AdminInfoUC : UserControl
    {
        private string username;

        public string Username { get => username; set => username = value; }

        public AdminInfoUC(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }
        public AdminInfoUC()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                updateBtn.Visible = false;
                confirmBtn.Visible = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                updateBtn.Visible = true;
                confirmBtn.Visible = false;
                string sex = "Nam";
                if (ChbFemale.Checked == true)
                    sex = "Nữ";
                if (DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.Update_Info_NhanVien @IDNV , @Name , @Sex , @Dateofbirth , @Phone , @CCCD , @Mail ", new object[] { txbManhanvien.Text, txbName.Text, sex, DateOfBirth.Value.ToString("yyyy/MM/dd"), txbPhone.Text, txbCCCD.Text, txbMail.Text }) != 0)
                {
                    MessageBox.Show("Cập nhập thành công.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Cập nhập thất bại.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadFormProperties()
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

        private void ChbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbFemale.Checked)
            {
                ChbMale.Checked = false;
            }
        }

        private void ChbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbMale.Checked)
            {
                ChbFemale.Checked = false;
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
        }// Kiểm tra mức độ phức tạp của password
    }
}
