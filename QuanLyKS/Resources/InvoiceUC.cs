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
    public partial class InvoiceUC : UserControl
    {
        public InvoiceUC()
        {
            InitializeComponent();
            LoadFormInvoice();
        }
        public void LoadFormInvoice()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuerry("SELECT IDBienLai AS 'Mã biên lai', IDKhach AS 'Mã khách hàng',TrangThai , MaPhong AS 'Mã phòng', IDNV, TienCoc, NgayVao AS 'Ngày vào', NgayRa AS 'Ngày ra', TienPhong, discount, VAT, TongTien, TenPhuongThuc  FROM dbo.BienLai WHERE TrangThai = 1");
                dtgvInvoice.DataSource = data;
                dtgvInvoice.Columns["IDNV"].Visible = false;
                dtgvInvoice.Columns["TienCoc"].Visible = false;
                dtgvInvoice.Columns["TienPhong"].Visible = false;
                dtgvInvoice.Columns["discount"].Visible = false;
                dtgvInvoice.Columns["VAT"].Visible = false;
                dtgvInvoice.Columns["TongTien"].Visible = false;
                dtgvInvoice.Columns["TenPhuongThuc"].Visible = false;
                dtgvInvoice.Columns["TrangThai"].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadBindings()
        {
            try
            {
                txbMakhachhang.DataBindings.Clear();
                txbStatus.DataBindings.Clear();
                txbTiencoc.DataBindings.Clear();
                txbRoomcode.DataBindings.Clear();
                txbDatein.DataBindings.Clear();
                txbDateout.DataBindings.Clear();
                txbHoadon.DataBindings.Clear();
                txbManhanvien.DataBindings.Clear();
                txbtotalmoney.DataBindings.Clear();
                txbDiscount.DataBindings.Clear();
                txbVAT.DataBindings.Clear();
                txbPhuongthuc.DataBindings.Clear();

                txbMakhachhang.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never));
                txbStatus.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
                txbTiencoc.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "TienCoc", true, DataSourceUpdateMode.Never));
                txbRoomcode.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never));
                txbDatein.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "Ngày vào", true, DataSourceUpdateMode.Never));
                txbDateout.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "Ngày ra", true, DataSourceUpdateMode.Never));
                txbHoadon.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "Mã biên lai", true, DataSourceUpdateMode.Never));
                txbManhanvien.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "IDNV", true, DataSourceUpdateMode.Never));
                txbtotalmoney.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "TongTien", true, DataSourceUpdateMode.Never));
                txbDiscount.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "discount", true, DataSourceUpdateMode.Never));
                txbVAT.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "VAT", true, DataSourceUpdateMode.Never));
                txbPhuongthuc.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "TenPhuongThuc", true, DataSourceUpdateMode.Never));
                //
                DataGridViewRow data = dtgvInvoice.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (data != null)
                {
                    if (data.Cells["TrangThai"].Value.ToString() == "1")
                        txbStatus.Text = "Đã thanh toán";
                    else if (data.Cells["TrangThai"].Value.ToString() == "0")
                        txbStatus.Text = "Chưa thanh toán";
                    
                }
                txbTiencoc.Text = txbTiencoc.Text + " vnđ";
                txbtotalmoney.Text = txbtotalmoney.Text + " vnđ";
                txbDiscount.Text = txbDiscount.Text + " vnđ";
                txbVAT.Text = txbVAT.Text + " vnđ";
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadBindings();
        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuerry($"SELECT IDBienLai AS 'Mã biên lai', IDKhach AS 'Mã khách hàng',TrangThai , MaPhong AS 'Mã phòng', IDNV, TienCoc, NgayVao AS 'Ngày vào', NgayRa AS 'Ngày ra', TienPhong, discount, VAT, TongTien, TenPhuongThuc  FROM dbo.BienLai WHERE TrangThai = 1 AND (IDBienLai LIKE '%{txbSeach.Text}%' OR  IDKhach LIKE '%{txbSeach.Text}%' OR MaPhong LIKE '%{txbSeach.Text}%')");
            dtgvInvoice.DataSource = data;
        }
    }
}
