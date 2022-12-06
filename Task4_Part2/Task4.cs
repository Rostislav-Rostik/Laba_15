
using Microsoft.Data.SqlClient;
using System;
internal class Task4
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=ROSTISLAV\ROSTISLAV;Initial Catalog=Stationery;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
                Console.WriteLine(connection.State);
            }
        }
    }
}