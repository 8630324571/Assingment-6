/* Question 3 :- Update Student Details Using Connected Architecture*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_Lab_Assignment
{
    internal class Q3_UpdateData
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";


            Console.WriteLine("Enter Student ID :");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter New Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter New Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter New Course: ");
            string course = Console.ReadLine();

            Console.WriteLine("Enter New City: ");
            string city = Console.ReadLine();

            string query = "update Student set Name = @Name , Age = @Age" +
                "Course = @Course, City = @City where StudentId = @Id";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if(rows > 0)
               Console.WriteLine("Student Updated Successfully!");
            else
                Console.WriteLine("Student ID not found!");

            con.Close();

            Console.ReadLine();

        }
    }
}
