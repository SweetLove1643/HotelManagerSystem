using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.ClassObject
{
    public class GuestObject
    {
        private int id;
        private string name;
        private string sex;
        private DateTime dateofbrith;
        private string cccd;
        private string nationality;
        private string phone;
        private string mail;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Dateofbrith { get => dateofbrith; set => dateofbrith = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Mail { get => mail; set => mail = value; }
        
        public GuestObject() { }
        public GuestObject(int Id, string Name, string Sex, DateTime Dateofbrith, string Cccd, string Nationality, string Phone, string Mail)
        {
            this.Id = Id;
            this.Name = Name;
            this.Sex = Sex;
            this.Dateofbrith = Dateofbrith;
            this.Cccd = Cccd;
            this.Nationality = Nationality;
            this.Phone = Phone;
            this.Mail = Mail;
        }
        public GuestObject(DataRow row)
        {
            this.Id = (int)row["IDKhach"];
            this.Name = (string)row["TenKhach"];
            this.Sex = (string)row["GioiTinh"];
            this.Dateofbrith = (DateTime)row["NgaySinh"];
            this.Cccd = (string)row["CCCD"];
            this.Nationality = (string)row["QuocTich"];
            this.Phone = (string)row["SDT"];
            this.Mail = (string)row["Mail"];
        }
    }
}
