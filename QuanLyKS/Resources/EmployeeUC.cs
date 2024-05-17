using QuanLyKS.ClassFuncion;
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
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class EmployeeUC : UserControl
    {
        public EmployeeUC()
        {
            InitializeComponent();
            LoadFormEmployyes();
        }
        public void LoadFormEmployyes()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT IDNV AS 'Mã nhân viên',TenNV AS 'Tên nhân viên', GioiTinh AS 'Giới tính', NgaySinh AS 'Ngày sinh', SDT AS 'Số điện thoại', CCCD AS 'CCCD', Mail AS 'Mail', ChucVu AS 'Chức vụ' FROM dbo.NhanVien WHERE ChucVu = N'Nhân viên' ");
                dtgvEmployyes.DataSource = data;
                dtgvEmployyes.Columns["Mã nhân viên"].Visible = false;
                dtgvEmployyes.Columns["Giới tính"].Visible = false;
                dtgvEmployyes.Columns["Ngày sinh"].Visible = false;
                dtgvEmployyes.Columns["Số điện thoại"].Visible = false;
                dtgvEmployyes.Columns["CCCD"].Visible = false;
                dtgvEmployyes.Columns["Mail"].Visible = false;
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
                if (IsValidPhoneNumber(txbPhone.Text))
                {
                    if (IsValidEmail(txbMail.Text))
                    {
                        string sex = "Nam";
                        if (ChbFemale.Checked == true)
                            sex = "Nữ";
                        DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.NhanVien SET TenNV = N'{txbName.Text}', GioiTinh = '{sex}', NgaySinh = '{DateOfBirth.Value.ToString("yyyy/MM/dd")}', SDT = '{txbPhone.Text}', CCCD = '{txbCCCD.Text}', Mail = '{txbMail.Text}' WHERE IDNV = {txbManhanvien.Text}");
                        MessageBox.Show("Cập nhập thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadFormEmployyes();
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

        private void dtgvEmployyes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            confirmBtn.Visible = true;
            deleteBtn.Visible = true;
            LoadBidings();
        }
        private void LoadBidings()
        {
            try
            {
                txbManhanvien.DataBindings.Clear();
                txbName.DataBindings.Clear();
                txbPhone.DataBindings.Clear();
                txbCCCD.DataBindings.Clear();
                txbMail.DataBindings.Clear();
                txbPosition.DataBindings.Clear();
                DateOfBirth.DataBindings.Clear();
                ChbFemale.DataBindings.Clear();
                ChbMale.DataBindings.Clear();
                ChbFemale.Checked = false;
                ChbMale.Checked = false;

                txbManhanvien.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never));
                txbName.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "Tên nhân viên", true, DataSourceUpdateMode.Never));
                txbPhone.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never));
                txbCCCD.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "CCCD", true, DataSourceUpdateMode.Never));
                txbMail.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "Mail", true, DataSourceUpdateMode.Never));
                txbPosition.DataBindings.Add(new Binding("Text", dtgvEmployyes.DataSource, "Chức vụ", true, DataSourceUpdateMode.Never));
                DateOfBirth.DataBindings.Add(new Binding("Value", dtgvEmployyes.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never));
                DataGridViewRow dt = dtgvEmployyes.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (dt != null)
                {
                    if (dt.Cells["Giới tính"].Value.ToString() == "Nam")
                        ChbMale.Checked = true;
                    else if (dt.Cells["Giới tính"].Value.ToString() == "Nữ")
                        ChbFemale.Checked = true;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDNV AS 'Mã nhân viên',TenNV AS 'Tên nhân viên', GioiTinh AS 'Giới tính', NgaySinh AS 'Ngày sinh', SDT AS 'Số điện thoại', CCCD AS 'CCCD', Mail AS 'Mail', ChucVu AS 'Chức vụ' FROM dbo.NhanVien WHERE TenNV LIKE '%{txbSeach.Text}%' AND ChucVu = N'Nhân viên'");
                dtgvEmployyes.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry($"SELECT SDT FROM dbo.NhanVien WHERE IDNV = {txbManhanvien.Text}");
                string phone = null;
                if (dt.Rows.Count > 0)
                {
                    phone = dt.Rows[0]["SDT"].ToString();
                }
                DataProvider.Instance.ExecuteNonQuerry($"DELETE FROM dbo.NhanVien WHERE IDNV = {txbManhanvien.Text}");
                DataProvider.Instance.ExecuteNonQuerry($"DELETE FROM dbo.TaiKhoan WHERE SDT = {phone}");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChbMale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChbMale.Checked == true)
                {
                    ChbFemale.Checked = false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChbFemale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChbFemale.Checked == true)
                {
                    ChbMale.Checked = false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
    }
}
