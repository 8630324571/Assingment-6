/*Q5 :- Create a C# program using SqlDataAdapter and DataSet to retrieve and
 display all records from the Student table*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace ADO.NET_Lab_Assignment
{
    internal class Q5_Retrieve_Data
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";

            string query = "Select * from Student";

            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            DataTable table = ds.Tables[0];

            Console.WriteLine("Student Reacords");
            Console.WriteLine("----------------------------");

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(
                    row["StudentId"]+ " " +
                    row["Name"]+ " " +
                    row["Age"]+ " "+
                    row["Course"]+ " "+
                    row["City"]
                    );
            }
            Console.ReadLine();

        }
    }
}
