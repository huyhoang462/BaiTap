using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {

        //database connection 's information
        SqlConnection myConn = new SqlConnection("Server=LAPTOP-TE90HW\\SQLEXPRESS;Database=LOGINLTTQ;User Id=sa;Password=123456;");
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConn.Open();
            String str = "SELECT * FROM LOG_INFOR";

            SqlCommand command = new SqlCommand(str, myConn);
            
            //For select
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (reader.GetString(0) == textBox1.Text && reader.GetString(1) == textBox2.Text)
                {
                    MessageBox.Show("SUCCESSED");
                    myConn.Close();
                    return;
                }
                
            }
            MessageBox.Show("BRUH");
            myConn.Close();


        }

    }
}
