using QuanLyKS.ClassFuncion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class Check_inUC : UserControl
    {
        private string idnv;

        public string Idnv { get => idnv; set => idnv = value; }

        public Check_inUC()
        {
            InitializeComponent();
            LoadFormCheckIn();
        }
        public void LoadFormCheckIn()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng',Mota AS 'Mô tả', Gia AS 'Giá', SucChua AS 'Sức chứa' FROM dbo.Phong WHERE TrangThai = 0");
                dtgvRoomCheckin.DataSource = data;
                dtgvRoomCheckin.Columns["Mô tả"].Visible = false;
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
                txbRoomcode.DataBindings.Clear();
                txbRoomprice.DataBindings.Clear();
                rtbMota.DataBindings.Clear();

                txbRoomcode.DataBindings.Add(new Binding("Text", dtgvRoomCheckin.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never));
                txbRoomprice.DataBindings.Add(new Binding("Text", dtgvRoomCheckin.DataSource, "Giá", true, DataSourceUpdateMode.Never));
                rtbMota.DataBindings.Add(new Binding("Text", dtgvRoomCheckin.DataSource, "Mô tả", true, DataSourceUpdateMode.Never));

                txbVAT.Text = ((double.Parse(txbRoomprice.Text)) * 0.1).ToString();
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
                DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng',Mota AS 'Mô tả', Gia AS 'Giá', SucChua AS 'Sức chứa' FROM dbo.Phong WHERE TrangThai = 0 AND (MaPhong LIKE '%{txbSeach.Text}%' OR LoaiPhong LIKE '%{txbSeach.Text}%')");
                dtgvRoomCheckin.DataSource = data;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvRoomCheckin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBindings();
            btnCorrect.Visible = true;
        }

        private void txbCorrect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbUserName.Text != null)
                {
                    if (DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateNewReceipt @Name , @Roomcode , @IDNV , @Roomprice , @Discount , @VAT ", new object[] {txbUserName.Text, txbRoomcode.Text, Idnv, txbRoomprice.Text, txbDiscount.Text, txbVAT.Text}) > 0)
                    {
                        DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.Phong SET TrangThai = 1 WHERE MaPhong = '{txbRoomcode.Text}'");
                        MessageBox.Show("Check-in thành công", "Messages", MessageBoxButtons.OK);
                        LoadFormCheckIn();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
