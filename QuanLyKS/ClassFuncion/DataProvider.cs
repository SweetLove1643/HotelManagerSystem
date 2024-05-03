using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace QuanLyKS.ClassFuncion
{
    public abstract class Execute
    {
        public abstract DataTable ExecuteQuerry(string querry, object[] parameter = null);// Thực hiện query và trả về kết quả query(trả về 1 datetable)
        public abstract int ExecuteNonQuerry(string querry, object[] parameter = null);// Thực hiện querry và trả về số lượng thành công
        public abstract object ExecuteScalar(string querry, object[] parameter = null);// Thực hiện query và trả về kết quả đầu tiên của kết quảs
    }
    public class DataProvider : Execute
    {
        private static DataProvider instance;
        private string connectionSTR = "Data source = SWEETLOVE; initial catalog = DBHotelManagerSystem; Integrated Security = True";
        public static DataProvider Instance
        {
            get
            {
                if(instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private DataProvider() { }

        public override DataTable ExecuteQuerry(string querry, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);

                if(parameter != null)
                {
                    string[] listPara = querry.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public override int ExecuteNonQuerry(string querry, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);

                if (parameter != null)
                {
                    string[] listPara = querry.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;

        }
        public override object ExecuteScalar(string querry, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);

                if (parameter != null)
                {
                    string[] listPara = querry.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;

        }
    }
}
