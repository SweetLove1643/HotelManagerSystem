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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class AccountUC : UserControl
    {
        private string phone;
        private string mail;
        private int choose = 0;
        public string Phone { get => phone; set => phone = value; }
        public string Mail { get => mail; set => mail = value; }

        public AccountUC()
        {
            InitializeComponent();
            LoadFormAccount();
        }
        public void LoadFormAccount()
        {
            try
            {
                var tlhd = dtgvAccount.TopLeftHeaderCell;
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT SDT AS 'Số điện thoại', Mail AS 'Mail', LoaiTaiKhoan AS 'Loại tài khoản' FROM dbo.TaiKhoan WHERE LoaiTaiKhoan = N'Nhân viên' OR LoaiTaiKhoan = N'Khách hàng'");
                dtgvAccount.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillEmployyes()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT SDT AS 'Số điện thoại', Mail AS 'Mail', LoaiTaiKhoan AS 'Loại tài khoản' FROM dbo.TaiKhoan WHERE LoaiTaiKhoan = N'Nhân viên'");
                dtgvAccount.DataSource = data;
                choose = 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillCustomer()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT SDT AS 'Số điện thoại', Mail AS 'Mail', LoaiTaiKhoan AS 'Loại tài khoản' FROM dbo.TaiKhoan WHERE LoaiTaiKhoan = N'Khách hàng'");
                dtgvAccount.DataSource = data;
                choose = 2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapquyen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn cấp quyền cho tài khoản này ?", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DataProvider.Instance.ExecuteNonQuerry("UPDATE dbo.TaiKhoan SET LoaiTaiKhoan = 'Nhân viên' WHERE SDT = @Phone ", new object[] { Phone });
                    ConvertCustomerToEmployee();
                }
                if (choose == 0)
                    LoadFormAccount();
                else if (choose == 1)
                    FillEmployyes();
                else if (choose == 2)
                    FillCustomer();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnCapquyen.Enabled = true;
                btnTuocquyen.Enabled = true;
                DataGridViewRow dtgvr = dtgvAccount.SelectedRows[0];
                Phone = dtgvr.Cells[0].Value.ToString();
                Mail = dtgvr.Cells[1].Value.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTuocquyen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn tước quyền cho tài khoản này ?", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DataProvider.Instance.ExecuteNonQuerry("UPDATE dbo.TaiKhoan SET LoaiTaiKhoan = N'Khách hàng' WHERE SDT = @Phone ", new object[] {Phone});
                    ConvertEmployeeToCustomer();
                }

                if (choose == 0)
                    LoadFormAccount();
                else if (choose == 1)
                    FillEmployyes();
                else if (choose == 2)
                    FillCustomer();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT SDT AS 'Số điện thoại', Mail AS 'Mail', LoaiTaiKhoan AS 'Loại tài khoản' FROM dbo.TaiKhoan WHERE (SDT LIKE '%{txbSeach.Text}%' OR Mail LIKE '%{txbSeach.Text}%') AND (LoaiTaiKhoan = N'Nhân viên' OR LoaiTaiKhoan = N'Khách hàng')");
            dtgvAccount.DataSource = data;

        }
        private void ConvertEmployeeToCustomer()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT * FROM dbo.NhanVien WHERE SDT = {Phone}");
                if (data.Rows.Count > 0)
                {
                    PersonnelObject personnel = new PersonnelObject(data.Rows[0]);
                    DataProvider.Instance.ExecuteNonQuerry("DELETE FROM dbo.NhanVien WHERE SDT = @sdt ", new object[] { Phone });
                    DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateNewGuest @Guestname , @Sex , @DateOfBrith , @CCCD , @Nationality , @Phone , @Mail ", new object[] { personnel.Name, personnel.Sex, personnel.Dateofbrith.ToString("yyyy/MM/dd"), personnel.Cccd, personnel.Nationaly, personnel.Phone, personnel.Mail });
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConvertCustomerToEmployee()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT * FROM dbo.Khach WHERE SDT = {Phone}");
                if (data.Rows.Count > 0)
                {
                    GuestObject personnel = new GuestObject(data.Rows[0]);
                    DataProvider.Instance.ExecuteNonQuerry("DELETE FROM dbo.Khach WHERE SDT = @sdt ", new object[] { Phone });
                    DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateNewPersonnel @Name , @Sex , @DateofBrith , @Position , @Phone , @CCCD , @Mail , @Nationality ", new object[] {personnel.Name, personnel.Sex, personnel.Dateofbrith.ToString("yyyy/MM/dd"), "Nhân viên", personnel.Phone, personnel.Cccd, personnel.Mail, personnel.Nationality});
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
