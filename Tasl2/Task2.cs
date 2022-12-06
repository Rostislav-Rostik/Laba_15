using Microsoft.Data.SqlClient;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=ROSTISLAV\ROSTISLAV;Initial Catalog=Students_Marks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string cmd = "SELECT * FROM Marks";
        string cmd_min = "SELECT * FROM Marks";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine(connection.State);
            SqlCommand command_1 = new SqlCommand(cmd, connection);
            SqlDataReader reader_1 = command_1.ExecuteReader();
            if (reader_1.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}", reader_1.GetName(0), reader_1.GetName(1), reader_1.GetName(2), reader_1.GetName(3), reader_1.GetName(4), reader_1.GetName(5));
                while (reader_1.Read())
                {
                    object Student_id = reader_1.GetValue(0);
                    object Name = reader_1.GetValue(1);
                    object Group_name = reader_1.GetValue(2);
                    object Avg_marks = reader_1.GetValue(3);
                    object name_min_marks = reader_1.GetValue(4);
                    object name_max_marks = reader_1.GetValue(5);

                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", Student_id, Name, Group_name, Avg_marks, name_min_marks, name_max_marks);
                }
            }
            reader_1.Close();
            Console.WriteLine("\n");
            SqlCommand command_2 = new SqlCommand(cmd, connection);
            SqlDataReader reader_2 = command_2.ExecuteReader();
            if (reader_2.HasRows)
            {
                Console.WriteLine("{0}\t{1}", reader_2.GetName(0), reader_2.GetName(1));
                while (reader_2.Read())
                {
                    object Student_id = reader_2.GetValue(0);
                    object Name = reader_2.GetValue(1);
                    Console.WriteLine("{0}\t\t{1}", Student_id, Name);
                }
            }
            reader_2.Close();

            Console.WriteLine("\n");
            SqlCommand command_3 = new SqlCommand(cmd, connection);
            SqlDataReader reader_3 = command_3.ExecuteReader();
            if (reader_3.HasRows)
            {
                Console.WriteLine("{0}", reader_3.GetName(3));
                while (reader_3.Read())
                {
                    object Avg_marks = reader_3.GetValue(3);
                    Console.WriteLine("{0}", Avg_marks);
                }
            }
            reader_3.Close();

            Console.WriteLine("\n");
            Console.Write("Enter a mark: ");
            int mark = int.Parse(Console.ReadLine());
            string cmd_subj_min = String.Format ("SELECT * FROM Marks WHERE AVG_marks > ('{0}')", mark);

            SqlCommand command_4 = new SqlCommand(cmd_subj_min, connection);
            SqlDataReader reader_4 = command_4.ExecuteReader();
            if (reader_4.HasRows)
            {
                Console.WriteLine("{0}", reader_4.GetName(1));
                while (reader_4.Read())
                { 
                    object name_min_marks = reader_4.GetValue(1);
                    Console.WriteLine("{0}", name_min_marks);
                }
            }
            reader_4.Close();

            Console.WriteLine("\n");
            SqlCommand command_5 = new SqlCommand(cmd_min, connection);
            SqlDataReader reader_5 = command_5.ExecuteReader();
            if (reader_5.HasRows)
            {
                Console.WriteLine("{0}", reader_5.GetName(4));
                while (reader_5.Read())
                {
                    object name_min_marks = reader_5.GetValue(4);
                    Console.WriteLine("{0}", name_min_marks);
                }
            }
            reader_5.Close();
        }
    }
}