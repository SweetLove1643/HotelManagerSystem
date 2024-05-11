using QuanLyKS.ClassFuncion;
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
    public partial class CustomerUC : UserControl
    {
        public CustomerUC()
        {
            InitializeComponent();
            LoadFormCustomer();
        }
        public void LoadFormCustomer()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT IDKhach AS 'Mã khách', TenKhach AS 'Tên khách hàng',  GioiTinh AS 'Giới tính', NgaySinh AS 'Ngày sinh', CCCD AS 'CCCD', QuocTich AS 'Quốc tịch', SDT AS 'Số điện thoại', Mail AS 'Mail' FROM dbo.Khach");
                dtgvCustomer.DataSource = data;
                dtgvCustomer.Columns["Mã khách"].Visible = false;
                dtgvCustomer.Columns["Giới tính"].Visible = false;
                dtgvCustomer.Columns["Ngày sinh"].Visible = false;
                dtgvCustomer.Columns["CCCD"].Visible = false;
                dtgvCustomer.Columns["Quốc tịch"].Visible = false;
                dtgvCustomer.Columns["Số điện thoại"].Visible = false;
                dtgvCustomer.Columns["Mail"].Visible = false;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddBindings()
        {
            try
            {
                txbMakhachhang.DataBindings.Clear();
                txbName.DataBindings.Clear();
                ChbFemale.DataBindings.Clear();
                ChbMale.DataBindings.Clear();
                DateOfBirth.DataBindings.Clear();  
                txbPhone.DataBindings.Clear();
                txbCCCD.DataBindings.Clear();
                txbMail.DataBindings.Clear();
                txbNationality.DataBindings.Clear();

                txbMakhachhang.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Mã khách", true, DataSourceUpdateMode.Never));
                txbName.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Tên khách hàng", true, DataSourceUpdateMode.Never));
                DateOfBirth.DataBindings.Add(new Binding("Value", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never));
                txbPhone.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never));
                txbCCCD.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "CCCD", true, DataSourceUpdateMode.Never));
                txbMail.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Mail", true, DataSourceUpdateMode.Never));
                txbNationality.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Quốc tịch", true, DataSourceUpdateMode.Never));
                DataGridViewRow dt = dtgvCustomer.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
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

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBindings();
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDKhach AS 'Mã khách', TenKhach AS 'Tên khách hàng',  GioiTinh AS 'Giới tính', NgaySinh AS 'Ngày sinh', CCCD AS 'CCCD', QuocTich AS 'Quốc tịch', SDT AS 'Số điện thoại', Mail AS 'Mail' FROM dbo.Khach WHERE TenKhach LIKE '%{txbSeach.Text}%'");
                dtgvCustomer.DataSource = data;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
