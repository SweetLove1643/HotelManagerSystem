using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKS.ClassFuncion
{
    public class GetAccountDB
    {
        private static GetAccountDB instance;
        public static GetAccountDB Instance
        {
            get
            {
                if(instance == null)
                    instance = new GetAccountDB();
                return GetAccountDB.Instance;
            }
            set
            {
                instance = value;
            }
        }
        /*
        public string GetPasswordByUsername(string username)
        {

        }
        */
    }
}
