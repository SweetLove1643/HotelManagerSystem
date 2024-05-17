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
    public partial class PaymentUC : UserControl
    {
        private string idbienlai;

        public string Idbienlai { get => idbienlai; set => idbienlai = value; }

        public PaymentUC()
        {
            InitializeComponent();
            LoadFormPayment();
        }
        public void LoadFormPayment()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT IDBienLai as 'Mã biên lai', TenKhach AS 'Tên khách', IDKhach, MaPhong AS 'Mã phòng', NgayVao, discount, VAT, TienPhong FROM dbo.BienLai WHERE TrangThai = 0");
                dtgvPayment.DataSource = data;
                dtgvPayment.Columns["Ngayvao"].Visible = false;
                dtgvPayment.Columns["IDKhach"].Visible = false;
                dtgvPayment.Columns["discount"].Visible = false;
                dtgvPayment.Columns["VAT"].Visible = false;
                dtgvPayment.Columns["TienPhong"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Addbindings()
        {
            try
            {
                txbUserName.DataBindings.Clear();
                txbGuestcode.DataBindings.Clear();
                txbTotalprice.DataBindings.Clear();
                txbRoomcode.DataBindings.Clear();
                txbPhuongthuc.DataBindings.Clear();
                DateOfBirth.DataBindings.Clear();

                txbUserName.DataBindings.Add(new Binding("Text", dtgvPayment.DataSource, "Tên khách", true, DataSourceUpdateMode.Never));
                txbRoomcode.DataBindings.Add(new Binding("Text", dtgvPayment.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never));
                txbGuestcode.DataBindings.Add(new Binding("Text", dtgvPayment.DataSource, "IDKhach", true, DataSourceUpdateMode.Never));
                DateOfBirth.DataBindings.Add(new Binding("Value", dtgvPayment.DataSource, "NgayVao", true, DataSourceUpdateMode.Never));
                DataGridViewRow data = dtgvPayment.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (data != null)
                {
                    TimeSpan timeSpan = DateTime.Now - DateOfBirth.Value;
                    this.Idbienlai = data.Cells["Mã biên lai"].Value.ToString();
                    txbTotalprice.Text = (timeSpan.TotalDays * double.Parse(data.Cells["TienPhong"].Value.ToString()) - double.Parse(data.Cells["discount"].Value.ToString()) + double.Parse(data.Cells["VAT"].Value.ToString())).ToString();
                    double total = Math.Round(double.Parse(txbTotalprice.Text), 2);
                    if(total < 0)
                    {
                        total = 0;
                    }
                    txbTotalprice.Text = total.ToString() + " vnđ";
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Addbindings();
            btnThanhtoan.Visible = true;
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txbPhuongthuc.Text))
                {
                    MessageBox.Show("Vui lòng nhập phương thức thanh toán !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.Phong SET TrangThai = 0 WHERE MaPhong = '{txbRoomcode.Text}'");
                    DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.BienLai SET TenPhuongThuc = '{txbPhuongthuc.Text}', NgayRa = '{DateTime.Now.ToString("yyyy/MM/dd")}' WHERE IDBienLai = '{Idbienlai}'");
                    MessageBox.Show("Thanh toán thành công", "Messages", MessageBoxButtons.OK);
                    LoadFormPayment();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDBienLai as 'Mã biên lai', TenKhach AS 'Tên khách', IDKhach, MaPhong AS 'Mã phòng', NgayVao, discount, VAT, TienPhong FROM dbo.BienLai WHERE TrangThai = 0 AND (IDBienLai LIKE '%{txbSeach.Text}%' OR TenKhach LIKE '%{txbSeach.Text}%')");
            dtgvPayment.DataSource = data;
        }
    }
}
