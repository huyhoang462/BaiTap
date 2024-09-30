using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cattle.DAL
{
  
    public class SQLConnectionData
    {
        // tạo singleton parttern 
        private static SQLConnectionData instance;
        public static SQLConnectionData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLConnectionData();
                }
                return instance;
            }
        }
        public SQLConnectionData() { }

        // tạo chuỗi kết nói 
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=LAPTOP-TE90HW\\HUYHOANG;Initial Catalog=Animal;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            SqlConnection con = new SqlConnection(strcon); 
            return con;
        }

        public int ExecuteQuery(string query)
        {
            using (SqlConnection con = Connect())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int result = cmd.ExecuteNonQuery(); 
                con.Close();
                return result;
            }
        }

        public int InsertData(string query)
        {
            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; 
            }
        }

        public int DeleteData(string query)
        {
            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; 
            }
        }
    }
}
