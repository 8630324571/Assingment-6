

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Lab_Assignment
{
    internal class Q10_Complete_CRUD_op_botharchitecture
    {
        static string connectionString = @"Data Source=DESKTOP-5B22L13\SQLEXPRESS01;Initial Catalog=StudentDB;Integrated Security=True";

        static void Main()
        {
            Console.WriteLine("==== ADO.NET CRUD OPERATIONS====");
            Console.WriteLine("1. Connected Architecture");
            Console.WriteLine("2. Disconnected Architecture");
            Console.WriteLine("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                ConnectedCRUD();
            }
            else if (choice == 2)
            {
                DisconnectedCRUD();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.ReadLine();
        }

        // ==============================
        // CONNECTED ARCHITECTURE
        // ==============================
        static void ConnectedCRUD()
        {
            Console.WriteLine("\n===== CONNECTED ARCHITECTURE =====");

            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            if (choice == 1)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                string query =
                    "INSERT INTO Student(Name, Age, Course, City) " +
                    "VALUES(@Name, @Age, @Course, @City)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Course", course);
                cmd.Parameters.AddWithValue("@City", city);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Student inserted successfully.");
            }

            else if (choice == 2)
            {
                string query = "SELECT * FROM Student";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nStudent Records");
                Console.WriteLine("--------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine(
                        reader["StudentId"] + " " +
                        reader["Name"] + " " +
                        reader["Age"] + " " +
                        reader["Course"] + " " +
                        reader["City"]
                    );
                }

                reader.Close();
            }

            else if (choice == 3)
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter New City: ");
                string city = Console.ReadLine();

                string query =
                    "UPDATE Student SET Name=@Name, Age=@Age, " +
                    "Course=@Course, City=@City " +
                    "WHERE StudentId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Course", course);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Id", id);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Student updated successfully.");
                else
                    Console.WriteLine("Student not found.");
            }

            else if (choice == 4)
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string query =
                    "DELETE FROM Student WHERE StudentId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Student deleted successfully.");
                else
                    Console.WriteLine("Student not found.");
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }

            con.Close();
        }


        // ==============================
        // DISCONNECTED ARCHITECTURE
        // ==============================
        static void DisconnectedCRUD()
        {
            Console.WriteLine("\n===== DISCONNECTED ARCHITECTURE =====");

            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            SqlDataAdapter adapter =
                new SqlDataAdapter(
                    "SELECT * FROM Student",
                    connectionString
                );

            SqlCommandBuilder builder =
                new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Student");

            DataTable table = ds.Tables["Student"];

            if (choice == 1)
            {
                DataRow row = table.NewRow();

                Console.Write("Enter Name: ");
                row["Name"] = Console.ReadLine();

                Console.Write("Enter Age: ");
                row["Age"] = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Course: ");
                row["Course"] = Console.ReadLine();

                Console.Write("Enter City: ");
                row["City"] = Console.ReadLine();

                table.Rows.Add(row);

                adapter.Update(ds, "Student");

                Console.WriteLine("Student inserted successfully.");
            }

            else if (choice == 2)
            {
                Console.WriteLine("\nStudent Records");
                Console.WriteLine("--------------------------------");

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine(
                        row["StudentId"] + " " +
                        row["Name"] + " " +
                        row["Age"] + " " +
                        row["Course"] + " " +
                        row["City"]
                    );
                }
            }

            else if (choice == 3)
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                bool found = false;

                foreach (DataRow row in table.Rows)
                {
                    if (Convert.ToInt32(row["StudentId"]) == id)
                    {
                        Console.Write("Enter New Name: ");
                        row["Name"] = Console.ReadLine();

                        Console.Write("Enter New Age: ");
                        row["Age"] = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Course: ");
                        row["Course"] = Console.ReadLine();

                        Console.Write("Enter New City: ");
                        row["City"] = Console.ReadLine();

                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    adapter.Update(ds, "Student");
                    Console.WriteLine("Student updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }

            else if (choice == 4)
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

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
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }

        }
    }
}
