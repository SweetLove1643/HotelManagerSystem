using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class GuestInfoBillObject
    {
        private int id;
        private int idguest;
        private int idreceipt;

        public int Id { get => id; set => id = value; }
        public int Idguest { get => idguest; set => idguest = value; }
        public int Idreceipt { get => idreceipt; set => idreceipt = value; }
        public GuestInfoBillObject() { }
        public GuestInfoBillObject(int Id, int Idguest, int Idreceipt)
        {
            this.Id = Id;
            this.Idreceipt = Idreceipt;
            this.Idguest = Idguest;
        }
        public GuestInfoBillObject(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Idguest = (int)row["IDKhach"];
            this.Idreceipt = (int)row["IDBienLai"];
        }
    }
}
