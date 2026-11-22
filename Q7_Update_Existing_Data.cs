/*Using DataSet and SqlDataAdapter, develop a program to 
 * update an existing student record. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Lab_Assignment
{
    internal class Q7_Update_Existing_Data
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Student", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Student");
            Console.WriteLine("Enter Student ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            DataTable table = ds.Tables["Student"];
            bool found = false;

            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["StudentId"]) == id)
                {
                    Console.WriteLine("Enter New Name: ");
                    row["Name"] = Console.ReadLine();

                    Console.WriteLine("Enter New Age");
                    row["Age"] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Course: ");
                    row["Course"] = Console.ReadLine();

                    Console.WriteLine("Enter New City: ");
                    row["City"] = Console.ReadLine();

                    found = true;
                    break;
                }
            }
            if (found)
            {
                adapter.Update(ds, "Student");
                Console.WriteLine("Student Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            Console.ReadLine();
        }
    }
}
