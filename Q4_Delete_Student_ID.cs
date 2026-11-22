/*Q4. Delete Student Based on Student ID*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lab_Assignment
{
    internal class Q4_Delete_Student_ID
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";
            Console.WriteLine("Enter Student ID to delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = "Delete from Student Where StudentId = @Id";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Student deleted Successfully!");
            else
                Console.WriteLine("Student ID not found!");

            con.Close();

            Console.ReadLine();


        }
    }
}
