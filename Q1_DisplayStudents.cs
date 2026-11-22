//Q1. Display All Student Records Using SqlConnection, SqlCommand and SqlDataReader

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ADO.NET_Lab_Assignment
{
    internal class Q1_DisplayStudents
    {
        static void run(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";
            string query = "Select * from Student";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Student Records");
            Console.WriteLine("----------------------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    reader["StudentId"] + " " + 
                    reader["Name"]+ " "+
                    reader["Age"]+ " "+
                    reader["Course"]+ " " +
                    reader["City"]
                 );
            }

            reader.Close();
            con.Close();
            Console.ReadLine();
        }
    }
}
