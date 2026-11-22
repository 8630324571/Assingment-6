/*Using DataSet and SqlDataAdapter, develop a program to delete a student record
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Lab_Assignment
{
    internal class Q8_Delete_usingDATASET
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Student", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Student");

            Console.WriteLine("Enter Student ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            DataTable table = ds.Tables["Student"];

            bool found = false;

            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["StudentId"]) == id)
                {
                    row.Delete();
                    found = true;
                    break;
                }
            }

            if (found)
            {
                adapter.Update(ds, "Student");
                Console.WriteLine("Student deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            Console.ReadLine();
        }
    }
}
