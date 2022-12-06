using Microsoft.Data.SqlClient;
using System;
internal class Task4
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=ROSTISLAV\ROSTISLAV;Initial Catalog=Stationery;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string cmd = "SELECT * FROM Product";
        string cmd1 = "SELECT * FROM Sales";
        string max = "SELECT Type_stationery, [Count] FROM Product WHERE [Count] = (SELECT MAX([Count]) FROM Product)";
        string min = "SELECT Type_stationery, [Count] FROM Product WHERE [Count] = (SELECT MIN([Count]) FROM Product)";
        string min_price = "SELECT Type_stationery FROM Product WHERE Price = (SELECT MIN(Price) FROM Product)";
        string max_price = "SELECT Type_stationery FROM Product WHERE Price = (SELECT MAX(Price) FROM Product)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            
            connection.Open();
            Console.WriteLine(connection.State);
            SqlCommand command_1 = new SqlCommand(cmd, connection);
            SqlDataReader reader_1 = command_1.ExecuteReader();
            if (reader_1.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t\t{4}", reader_1.GetName(0), reader_1.GetName(1), reader_1.GetName(2), reader_1.GetName(3), reader_1.GetName(4));
                while (reader_1.Read())
                {
                    object Stationery_ID = reader_1.GetValue(0);
                    object Type_stationery = reader_1.GetValue(1);
                    object Count = reader_1.GetValue(2);
                    object Manager = reader_1.GetValue(3);
                    object Price = reader_1.GetValue(4);

                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", Stationery_ID, Type_stationery, Count, Manager, Price);
                }
            }
            reader_1.Close();

            Console.WriteLine("\n");
            SqlCommand command_2 = new SqlCommand(cmd1, connection);
            SqlDataReader reader_2 = command_2.ExecuteReader();
            if (reader_2.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t{3}\t\t{4}\t\t{5}", reader_2.GetName(0), reader_2.GetName(1), reader_2.GetName(2), reader_2.GetName(3), reader_2.GetName(4), reader_2.GetName(5));
                while (reader_2.Read())
                {
                    object Product_ID = reader_2.GetValue(0);
                    object Company = reader_2.GetValue(1);
                    object Manager = reader_2.GetValue(2);
                    object Count = reader_2.GetValue(3);
                    object Price = reader_2.GetValue(4);
                    object Date = reader_2.GetValue(5);

                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", Product_ID, Company, Manager, Count, Price, Date);
                }
            }
            reader_2.Close();

            Console.WriteLine("\n");
            SqlCommand command_3 = new SqlCommand(cmd, connection);
            SqlDataReader reader_3 = command_3.ExecuteReader();
            if (reader_3.HasRows)
            {
                Console.WriteLine("{0}",reader_3.GetName(1));
                while (reader_3.Read())
                {
                    object Type_stationery = reader_3.GetValue(1);

                    Console.WriteLine("{0}", Type_stationery);
                }
            }
            reader_3.Close();

            Console.WriteLine("\n");
            SqlCommand command_4 = new SqlCommand(cmd, connection);
            SqlDataReader reader_4 = command_4.ExecuteReader();
            if (reader_4.HasRows)
            {
                Console.WriteLine("{0}", reader_4.GetName(3));
                while (reader_4.Read())
                {
                    object Manager = reader_4.GetValue(3);

                    Console.WriteLine("{0}", Manager);
                }
            }
            reader_4.Close();

            Console.WriteLine("\n");
            SqlCommand command_5 = new SqlCommand(max, connection);
            object count_max = command_5.ExecuteScalar();
            Console.WriteLine(count_max);

            Console.WriteLine("\n");
            SqlCommand command_6 = new SqlCommand(min, connection);
            object count_min = command_6.ExecuteScalar();
            Console.WriteLine(count_min);

            Console.WriteLine("\n");
            SqlCommand command_7 = new SqlCommand(min_price, connection);
            object price_min = command_7.ExecuteScalar();
            Console.WriteLine(price_min);

            Console.WriteLine("\n");
            SqlCommand command_8 = new SqlCommand(max_price, connection);
            object price_max = command_8.ExecuteScalar();
            Console.WriteLine(price_max);
        }
    }
}