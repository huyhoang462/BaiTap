using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cattle.DAL
{
    public class AnimalsAccess
    {
        private AnimalsAccess() { }
        private static AnimalsAccess instance;
        public static AnimalsAccess Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new AnimalsAccess();
                }
                return instance;
            }

        }
        public int CountMilkCow()
        {
            string query = "SELECT Milk FROM Animals WHERE Name = 'Cow'";

            int MilkCow = SQLConnectionData.Instance.ExecuteQuery(query);
            return MilkCow;
        }

        public int CountMilkSheep()
        {
            string query = "SELECT Num FROM Animals WHERE Name = 'Sheep'";

            int MilkCow = SQLConnectionData.Instance.ExecuteQuery(query);
            return MilkCow;
        }

        public int CountMilkGoat()
        {
            string query = "SELECT Num FROM Animals WHERE Name = 'Goat'";

            int MilkCow = SQLConnectionData.Instance.ExecuteQuery(query);
            return MilkCow;
        }
        public void Reset()
        {
            string query = " DELETE FROM Animals";
            SQLConnectionData.Instance.DeleteData(query);
        }
        public int CountChildCow()
        {
            string query = "SELECT Child FROM Animals WHERE Name = 'Cow'";
            int Count = SQLConnectionData.Instance.ExecuteQuery(query);
            return Count;
        }
        public int CountChildSheep()
        {
            string query = "SELECT Child FROM Animals WHERE Name = 'Sheep'";
            int Count = SQLConnectionData.Instance.ExecuteQuery(query);
            return Count;
        }
        public int CountChildGoat()
        {
            string query = "SELECT Child FROM Animals WHERE Name = 'Goat'";
            int Count = SQLConnectionData.Instance.ExecuteQuery(query);
            return Count;
        }
        public void Insert(int num, int child, int milk, string name)
        {
            string query = "INSERT INTO Animals (Num, Child, Milk, Name) VALUES (@Num, @Child, @Milk, @Name)";

            // Tạo đối tượng SqlConnection
            using (SqlConnection connection = SQLConnectionData.Connect())
            {
                // Tạo đối tượng SqlCommand
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm các tham số vào câu lệnh
                command.Parameters.AddWithValue("@Num", num);
                command.Parameters.AddWithValue("@Child", child);
                command.Parameters.AddWithValue("@Milk", milk);
                command.Parameters.AddWithValue("@Name", name);

                // Mở kết nối
                connection.Open();

                // Thực thi câu lệnh
                command.ExecuteNonQuery();
            }
        }
    }
}
