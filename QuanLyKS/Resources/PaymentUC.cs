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
        private string idnv;

        public string Idbienlai { get => idbienlai; set => idbienlai = value; }
        public string Idnv { get => idnv; set => idnv = value; }

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
                    if (total < 0)
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
                if ((string.IsNullOrEmpty(txbUserName.Text) == false || string.IsNullOrEmpty(txbGuestcode.Text) == false) && string.IsNullOrEmpty(txbRoomcode.Text) == false)
                {
                    if (string.IsNullOrEmpty(txbPhuongthuc.Text))
                    {
                        MessageBox.Show("Vui lòng nhập phương thức thanh toán !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult inhoadon = MessageBox.Show("Bạn có muốn in hóa đơn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (inhoadon == DialogResult.Yes)
                        {
                            Inhoadon();
                        }
                        DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.Phong SET TrangThai = 0 WHERE MaPhong = '{txbRoomcode.Text}'");
                        DataProvider.Instance.ExecuteNonQuerry($"UPDATE dbo.BienLai SET TenPhuongThuc = '{txbPhuongthuc.Text}', NgayRa = '{DateTime.Now.ToString("yyyy/MM/dd")}' WHERE IDBienLai = '{Idbienlai}'");
                        MessageBox.Show("Thanh toán thành công", "Messages", MessageBoxButtons.OK);
                        LoadFormPayment();
                        txbUserName.Text = "";
                        txbGuestcode.Text = "";
                        txbPhuongthuc.Text = "";
                        txbRoomcode.Text = "";
                        txbTotalprice.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDBienLai as 'Mã biên lai', TenKhach AS 'Tên khách', IDKhach, MaPhong AS 'Mã phòng', NgayVao, discount, VAT, TienPhong FROM dbo.BienLai WHERE TrangThai = 0 AND (IDBienLai LIKE '%{txbSeach.Text}%' OR TenKhach LIKE '%{txbSeach.Text}%')");
            dtgvPayment.DataSource = data;
        }

        public void Inhoadon()
        {
            prfDialog.Document = prfDocument;
            prfDialog.ShowDialog();
        }

        private void prfDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int wight = prfDocument.DefaultPageSettings.PaperSize.Width;
            int height = prfDocument.DefaultPageSettings.PaperSize.Height;
            int row = 0;

            string Guestname = txbUserName.Text; ;
            string Guestcode = txbGuestcode.Text;
            string Roomcode = txbRoomcode.Text;
            string datein = DateOfBirth.Value.ToString("dd/MM/yyyy   HH:mm");
            string dateout = DateTime.Now.ToString("dd/MM/yyyy   HH:mm");
            string totalmoney = txbTotalprice.Text;
            string phuongthuc = txbPhuongthuc.Text;
            string idemployyes = Idnv;


            //Logo quán
            e.Graphics.DrawString(
                String.Format("BB Hotel"),
                new Font("Viner Hand ITC", 40, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight / 2 - 110, row = row + 70)
                );
            // Hóa đơn tính tiền
            e.Graphics.DrawString(
                String.Format("HÓA ĐƠN TÍNH TIỀN"),
                new Font("Courier New", 23, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight / 2 - 165, row = row + 90)
                );
            // Ngày tháng giờ tính tiền
            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy   HH:mm")),
                new Font("Courier New", 18, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight / 2 - 140, row = row + 50)
                );
            // Kẻ vạch
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, row = row + 40), new Point(wight - 10, row));
            // Tên khách hàng
            e.Graphics.DrawString(
                String.Format("Tên khách hàng: {0}", Guestname),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Mã khách hàng
            e.Graphics.DrawString(
                String.Format("Mã khách hàng: {0}", Guestcode),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Mã thu ngân
            e.Graphics.DrawString(
                String.Format("Mã thu ngân: {0}", idemployyes),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Mã phòng
            e.Graphics.DrawString(
                String.Format("Mã phòng: {0}", Roomcode),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Giờ vào
            e.Graphics.DrawString(
                String.Format("Giờ vào: {0}", datein),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Giờ ra
            e.Graphics.DrawString(
                String.Format("Giờ ra: {0}", dateout),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Tổng tiền
            e.Graphics.DrawString(
                String.Format("Tổng tiền: {0}", totalmoney),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Phương thức
            e.Graphics.DrawString(
                String.Format("Phương thức thanh toán: {0}", phuongthuc),
                new Font("Courier New", 15, FontStyle.Bold),
                Brushes.Black,
                new PointF(wight - (wight - 50), row = row + 40)
                );
            // Phụ
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, row = row + 50), new Point(wight - 10, row));
            e.Graphics.DrawString(
            String.Format("Cảm ơn quý khách, hẹn gặp lại !!!"),
            new Font("Times New Roman", 15, FontStyle.Bold),
            Brushes.Black,
            new PointF(wight / 2 - 140, row = row + 40)
            );
            e.Graphics.DrawLine(new Pen(Color.Black, 50), new Point(10, height - 30), new Point(wight - 10, height - 30));
            e.Graphics.DrawString(
            String.Format("Phone: 0947119702                                            Email: hotel.hl.hb@gmail.com"),
            new Font("Times New Roman", 15, FontStyle.Bold),
            Brushes.White,
            new PointF(80, height - 35)
            );
        }
    }
}
