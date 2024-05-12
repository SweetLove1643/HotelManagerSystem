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

namespace QuanLyKS
{
    public partial class Booking : Form
    {
        private string username;
        public string Username { get => username; set => username = value; }
        public Booking(string Username)
        {
            InitializeComponent();
            this.Username = Username;
            LoadFormBooking();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            User us = new User(this, Username);
            this.Hide();
            us.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LoadFormBooking()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng',Mota AS 'Mô tả', Gia AS 'Giá', SucChua AS 'Sức chứa' FROM dbo.Phong WHERE TrangThai = 0");
                dtgvroom.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Addbindings()
        {
            try
            {
                txbRoomcode.DataBindings.Clear();
                txbTiencoc.DataBindings.Clear();

                txbRoomcode.DataBindings.Add(new Binding("Text", dtgvroom.DataSource, "Mã phòng"));
                DataGridViewRow data = dtgvroom.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (data != null)
                {
                    txbRoomcode.Text = data.Cells["Mã phòng"].Value.ToString();
                    double coc = double.Parse(data.Cells["Giá"].Value.ToString()) * 0.3;
                    txbTiencoc.Text = coc.ToString();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvroom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Addbindings();
            btnBooking.Visible = true;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateCheckout.Value > DateCheckin.Value)
                {
                    string idguet = "";
                    DataTable data = DataProvider.Instance.ExecuteQuerry($" SELECT IDKhach FROM dbo.Khach WHERE SDT = '{Username}' OR Mail = '{Username}'");
                    if (data != null)
                    {
                        idguet = data.Rows[0]["IDKhach"].ToString();
                        DataProvider.Instance.ExecuteNonQuerry("EXEC dbo.CreateBooking @IDGuest , @Roomcode , @Checkin , @Checkout ,  @Coc ", new object[] {idguet, txbRoomcode.Text, DateCheckin.Value.ToString("yyyy/MM/dd"), DateCheckout.Value.ToString("yyyy/MM/dd"), txbTiencoc.Text });
                        MessageBox.Show("Đặt phòng thành công", "Messages", MessageBoxButtons.OK);
                        LoadFormBooking();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lại ngày trả phòng!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SelectRoom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("EXEC dbo.Select_Booking @Date1 , @Date2 ", new object[] { DateCheckin.Value.ToString("yyyy/MM/dd"), DateCheckout.Value.ToString("yyyy/MM/dd") });
                dtgvroom.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
