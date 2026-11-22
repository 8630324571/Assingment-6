/* Q6 :- Using disconnected architecture, develop a program to insert a
 * new student record using DataSet and SqlDataAdapter. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Lab_Assignment
{
    internal class Q6_Insert_Data_UsingDataSet
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Student", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Student");

            DataTable table = ds.Tables["Student"];

            DataRow row = table.NewRow();

            row["Name"] = "Rohit";
            row["Age"] = 23;
            row["Course"] = "MCA";
            row["City"] = "Faridabad";

            table.Rows.Add(row);

            adapter.Update(ds, "student");
            Console.WriteLine("Student inserted successfully.");

            Console.ReadLine();

        }
    }
}
