using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassFuncion
{
    public class Hashing
    {
        private static Hashing instance;
        public static Hashing Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hashing();
                return Hashing.instance;
            }
            set
            {
                Hashing.instance = value;
            }
        }
        public Hashing() { }
        public string Hash384(string text)
        {
            using (SHA384 sha384 = SHA384.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hashbytes = sha384.ComputeHash(bytes);

                return BitConverter.ToString(hashbytes).Replace("-","").ToLower();
            }
        }
    }
}
