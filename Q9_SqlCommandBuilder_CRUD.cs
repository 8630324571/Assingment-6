/* Q9 :- Create a program using SqlCommandBuilder to perform Insert, Update,
 * and Delete operations on the Student table through a DataSet. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ADO.NET_Lab_Assignment
{
    internal class Q9_SqlCommandBuilder_CRUD
    {
        static void run()
        {
            string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Student", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Student");

            Console.WriteLine("1. Inserted Student");
            Console.WriteLine("2. Updated Student");
            Console.WriteLine("3. Deleted Student");

            Console.WriteLine("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            DataTable table = ds.Tables["Student"];

            if (choice == 1)
            {
                DataRow row = table.NewRow();

                Console.WriteLine("Enter Name: ");
                row["Name"] = Console.ReadLine();

                Console.WriteLine("Enter Age: ");
                row["Age"] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Course: ");
                row["Course"] = Console.ReadLine();

                Console.WriteLine("Enter City :");
                row["City"] = Console.ReadLine();

                table.Rows.Add(row);

                adapter.Update(ds, "Student");
                Console.WriteLine("Student inserted Successfully!");
            }
            else if(choice == 2)
            {
                Console.WriteLine("Enter Student Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                bool found = false;

                foreach (DataRow row in table.Rows)
                {
                    if (Convert.ToInt32(row["Student"]) == id)
                    {
                        Console.WriteLine("Enter new Name: ");
                        row["Name"] = Console.ReadLine();

                        Console.WriteLine("Enter New Age: ");
                        row["Age"] = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter New Course: ");
                        row["Course"] = Console.ReadLine();

                        Console.WriteLine("Enter new City :");
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
                    Console.WriteLine("Student Not Found!");
                }
            }
            else if(choice == 3)
            {
                Console.WriteLine("Enter Student Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                bool found = false;
                foreach(DataRow row in table.Rows)
                {
                    if (Convert.ToInt32(Console.ReadLine()) == id)
                    {
                        row.Delete();
                        found = true;
                        break;

                    }
                }

                if (found)
                {
                    adapter.Update(ds, "Student");
                    Console.WriteLine("Student dalated Successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }

            Console.ReadLine();
        }
    }
}
