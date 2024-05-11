using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class ReceiptObject
    {
        private int idreceipt;
        private int idguest;
        private string roomcode;
        private int idpersonnel;
        private double deposit;
        private DateTime checkin;
        private DateTime checkout;
        private double roommoney;
        private double discount;
        private double vat;
        private double totalmoney;
        private string payment;
        private int status;
        private string name;

        public int Idreceipt { get => idreceipt; set => idreceipt = value; }
        public int Idguest { get => idguest; set => idguest = value; }
        public string Roomcode { get => roomcode; set => roomcode = value; }
        public int Idpersonnel { get => idpersonnel; set => idpersonnel = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public DateTime Checkin { get => checkin; set => checkin = value; }
        public DateTime Checkout { get => checkout; set => checkout = value; }
        public double Roommoney { get => roommoney; set => roommoney = value; }
        public double Discount { get => discount; set => discount = value; }
        public double VAT { get => vat; set => vat = value; }
        public double Totalmoney { get => totalmoney; set => totalmoney = value; }
        public string Payment { get => payment; set => payment = value; }
        public int Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }

        public ReceiptObject() { }
        public ReceiptObject(int Idreceipt, int Idguest, string Roomcode, int Idpersonnel, double Deposit, DateTime Checkin, DateTime Checkout, double Roommoney, double Discount, double VAT, double Totalmoney, string Payment, int Status, string Name)
        {
            this.Idreceipt = Idreceipt;
            this.Idguest = Idguest;
            this.Roomcode = Roomcode;
            this.Idpersonnel = Idpersonnel;
            this.Deposit = Deposit;
            this.Checkin = Checkin;
            this.Checkout = Checkout;
            this.Roommoney = Roommoney;
            this.Discount = Discount;
            this.VAT = VAT;
            this.Totalmoney = Totalmoney;
            this.Payment = Payment;
            this.Status = Status;
            this.Name = Name;

        }
        public ReceiptObject(DataRow row)
        {
            this.Idreceipt = (int)row["IDBienLai"];
            this.Idguest = (int)row["IDKhach"];
            this.Roomcode = (string)row["MaPhong"];
            this.Idpersonnel = (int)row["IDNV"];
            this.Deposit = (double)row["TienCoc"];
            this.Checkin = (DateTime)row["NgayVao"];
            this.Checkout = (DateTime)row["NgayRa"];
            this.Roommoney = (double)row["TienPhong"];
            this.Discount = (double)row["discount"];
            this.VAT = (double)row["VAT"];
            this.Totalmoney = (double)row["TongTien"];
            this.Payment = (string)row["TenPhuongThuc"];
            this.Status = (int)row["TrangThai"];
            this.Name = (string)row["TenKhach"];
        }
    }
}
