using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class AccountObject
    {
        private string sdt;
        private string mail;
        private string password;
        private string typeaccount;

        public string Sdt { get => sdt; set => sdt = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public string TypeAccount { get => typeaccount; set => typeaccount = value; }

        public AccountObject() { }
        public AccountObject(string Sdt, string Mail, string Password, string TypeAccount)
        {
            this.Sdt = Sdt;
            this.Mail = Mail;
            this.Password = Password;
            this.TypeAccount = TypeAccount;
        }
        public AccountObject(DataRow row)
        {
            this.Sdt = (string)row["SDT"];
            this.Mail = (string)row["Mail"];
            this.Password = (string)row["MatKhau"];
            this.TypeAccount = (string)row["LoaiTaiKhoan"];
        }
    }
}
