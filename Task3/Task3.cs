using Microsoft.Data.SqlClient;
using System;

internal class Task3
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=ROSTISLAV\ROSTISLAV;Initial Catalog=Students_Marks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string cmd_min = "SELECT MIN(AVG_marks) FROM Marks";
        string cmd_max = "SELECT MAX(AVG_marks) FROM Marks";
        string cmd_min_math = "SELECT COUNT(Name) FROM Marks WHERE name_min_marks LIKE 'Math'";
        string cmd_max_math = "SELECT COUNT(Name) FROM Marks WHERE name_max_marks LIKE 'Math'";
        string cmd_n_st = "SELECT Count(Group_name) FROM Marks GROUP BY Group_name";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine(connection.State);
            SqlCommand command = new SqlCommand(cmd_min, connection);
            object min_avg = command.ExecuteScalar();
            Console.WriteLine(min_avg);

            Console.WriteLine("\n");
            SqlCommand command_1 = new SqlCommand(cmd_max, connection);
            object max_avg = command_1.ExecuteScalar();
            Console.WriteLine(max_avg);

            Console.WriteLine("\n");
            SqlCommand command_2 = new SqlCommand(cmd_min_math, connection);
            object math = command_2.ExecuteScalar();
            Console.WriteLine(math);

            Console.WriteLine("\n");
            SqlCommand command_3 = new SqlCommand(cmd_max_math, connection);
            object math_max = command_3.ExecuteScalar();
            Console.WriteLine(math_max);

            Console.WriteLine("\n");
            SqlCommand command_4 = new SqlCommand(cmd_n_st, connection);
            SqlDataReader reader_4 = command_4.ExecuteReader();
            if (reader_4.HasRows)
            {
                while (reader_4.Read())
                {
                    object Group_name = reader_4.GetValue(0);
                    Console.WriteLine("{0}", Group_name);
                }
            }
            reader_4.Close();
        }
    }
}