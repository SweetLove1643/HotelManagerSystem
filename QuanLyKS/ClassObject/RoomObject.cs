using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassObject
{
    public class RoomObject
    {
        private string roomcode;
        private string roomtype;
        private string describe;
        private int status;
        private double money;
        private int capacity;

        public string Roomcode { get => roomcode; set => roomcode = value; }
        public string Roomtype { get => roomtype; set => roomtype = value; }
        public string Describe { get => describe; set => describe = value; }
        public int Status { get => status; set => status = value; }
        public double Money { get => money; set => money = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        
        public RoomObject() { }
        public RoomObject(string Roomcode, string Roomtype, string Describe, int Status, double Money, int Capacity)
        {
            this.Roomcode = Roomcode;
            this.Roomtype = Roomtype;
            this.Describe = Describe;
            this.Status = Status;
            this.Money = Money;
            this.Capacity = Capacity;
        }
        public RoomObject(DataRow row)
        {
            this.Roomcode = (string)row["MaPhong"];
            this.Roomtype = (string)row["LoaiPhong"];
            this.Describe = (string)row["Mota"];
            this.Status = (int)row["TrangThai"];
            this.Money = (double)row["Gia"];
            this.Capacity = (int)row["SucChua"];
        }
    }
}
