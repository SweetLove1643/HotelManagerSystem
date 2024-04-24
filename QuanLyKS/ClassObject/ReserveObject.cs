using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class ReserveObject
    {
        private int id;
        private int idguest;
        private string roomcode;
        private DateTime checkin;
        private DateTime checkout;
        private double deposit;

        public int Id { get => id; set => id = value; }
        public int Idguest { get => idguest; set => idguest = value; }
        public string Roomcode { get => roomcode; set => roomcode = value; }
        public DateTime Checkin { get => checkin; set => checkin = value; }
        public DateTime Checkout { get => checkout; set => checkout = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        
        public ReserveObject() { }
        public ReserveObject(int Id, int Idguest, string Roomcode, DateTime Checkin, DateTime Checkout, double Deposit)
        {
            this.Id = Id;
            this.Idguest = Idguest;
            this.Roomcode = Roomcode;
            this.Checkin = Checkin;
            this.Checkout = Checkout;
            this.Deposit = Deposit;
        }
        public ReserveObject(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Idguest = (int)row["IDKhach"];
            this.Roomcode = (string)row["MaPhong"];
            this.Checkin = (DateTime)row["NgayNhan"];
            this.Checkout = (DateTime)row["NgayTra"];
            this.Deposit = (double)row["TienCoc"];
        }
    }
}
