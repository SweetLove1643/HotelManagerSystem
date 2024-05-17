using Guna.UI2.WinForms;
using QuanLyKS.ClassFuncion;
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
    public partial class RoomUC : UserControl
    {
        public RoomUC()
        {
            InitializeComponent();
            LoadFormRoom();
        }
        private void AddBindings()
        {
            try
            {
                txbroomcode.DataBindings.Clear();
                txbroomtype.DataBindings.Clear();
                txbsucchua.DataBindings.Clear();
                txbprice.DataBindings.Clear();
                txbmota.DataBindings.Clear();
                cbStatus.DataBindings.Clear();
                //
                txbroomcode.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never));
                txbroomtype.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "Loại phòng", true, DataSourceUpdateMode.Never));
                txbsucchua.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "SucChua", true, DataSourceUpdateMode.Never));
                txbprice.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "Gia", true, DataSourceUpdateMode.Never));
                txbmota.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "Mota", true, DataSourceUpdateMode.Never));
                DataGridViewRow data = dtgvroom.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (data != null)
                {
                    string temp = data.Cells["TrangThai"].Value.ToString();
                    if (temp == "1")
                        cbStatus.Text = "Đang cho thuê";
                    else if (temp == "0")
                        cbStatus.Text = "Trống";
                    else if (temp == "-1")
                        cbStatus.Text = "Đang sửa chữa";
                }
                //
                txbprice.Text = txbprice.Text + " vnđ";
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadFormRoom()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng', Mota, TrangThai, Gia, SucChua FROM dbo.Phong");
                dtgvroom.DataSource = data;
                dtgvroom.Columns["Mota"].Visible = false;
                dtgvroom.Columns["TrangThai"].Visible = false;
                dtgvroom.Columns["Gia"].Visible = false;
                dtgvroom.Columns["SucChua"].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                updateBtn.Visible = true;
                deleteBtn.Visible = true;
                int status = 0;
                if (cbStatus.Text == "Đang sửa chữa")
                    status = -1;
                else if (cbStatus.Text == "Đang cho thuê")
                    status = 1;
                if (DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.Phong SET LoaiPhong = N'{txbroomtype.Text}' ,SucChua = {txbsucchua.Text} , Gia = {Regex.Replace(txbprice.Text, @"[^\d.]", "")} , TrangThai = {status} , Mota = N'{txbmota.Text}' WHERE MaPhong = N'{txbroomcode.Text}'") != 0)
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK);
                    LoadFormRoom();
                }
                else
                {
                    MessageBox.Show("Mã phòng này không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvroom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBindings();
            addBtn.Visible = true;
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng', Mota, TrangThai, Gia, SucChua FROM dbo.Phong WHERE MaPhong LIKE '%{txbSeach.Text}%' OR LoaiPhong LIKE '%{txbSeach.Text}%'");
                dtgvroom.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataProvider.Instance.ExecuteQuerry($"SELECT 1 FROM dbo.Phong WHERE MaPhong = '{txbroomcode.Text}'").Rows.Count > 0) 
                {
                    MessageBox.Show("Mã phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    int status = 0;
                    if (cbStatus.Text == "Đang sửa chữa")
                        status = -1;
                    else if (cbStatus.Text == "Đang cho thuê")
                        status = 1;
                    DataProvider.Instance.ExecuteQuerry("EXEC dbo.CreateNewRoom @Roomcode , @Roomtype , @Mota , @Status , @Price , @SucChua ", new object[] {txbroomcode.Text, txbroomtype.Text, txbmota.Text, status, Regex.Replace(txbprice.Text, @"[^\d.]", ""), txbsucchua.Text});
                    MessageBox.Show("Thêm phòng mới thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadFormRoom();
                }
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
                if (DataProvider.Instance.ExecuteNonQuerry($"DELETE FROM dbo.Phong WHERE MaPhong = '{txbroomcode.Text}'") != 0)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK);
                    LoadFormRoom();
                }
                else
                {
                    MessageBox.Show("Phòng này không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                if((e.KeyChar == '.') && (sender as Guna2TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbsucchua_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
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
