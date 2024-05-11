using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class PersonnelObject
    {
        private int idnv;
        private string name;
        private string sex;
        private DateTime dateofbrith;
        private string position;
        private string phone;
        private string cccd;
        private string mail;
        private string nationaly;
        public int Idnv { get => idnv; set => idnv = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Dateofbrith { get => dateofbrith; set => dateofbrith = value; }
        public string Position { get => position; set => position = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Nationaly { get => nationaly; set => nationaly = value; }

        public PersonnelObject() { }

        public PersonnelObject(int Idnv, string Name, string Sex, DateTime Date, string Position, string Phone, string Cccd, string Mail, string Nationaly)
        {
            this.Idnv = Idnv;
            this.Name = Name;
            this.Sex = Sex;
            this.Dateofbrith = Date;
            this.Position = Position;
            this.Phone = Phone;
            this.Cccd = Cccd;
            this.Mail = Mail;
            this.Nationaly = Nationaly;
        }
        public PersonnelObject(DataRow row)
        {
            this.Idnv = (int)row["IDNV"];
            this.Name = (string)row["TenNV"];
            this.Sex = (string)row["GioiTinh"];
            this.Dateofbrith = (DateTime)row["NgaySinh"];
            this.Position = (string)row["ChucVu"];
            this.Phone = (string)row["SDT"];
            this.Cccd = (string)row["CCCD"];
            this.Mail = (string)row["Mail"];
            this.Nationaly = (string)row["QuocTich"];
        }
    }
}
