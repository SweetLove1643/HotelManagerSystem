using System;
using System.Collections.Generic;
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
        public PersonnelObject() { }
        public PersonnelObject(int ID)
        public int Idnv { get => idnv; set => idnv = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Dateofbrith { get => dateofbrith; set => dateofbrith = value; }
    }
}
