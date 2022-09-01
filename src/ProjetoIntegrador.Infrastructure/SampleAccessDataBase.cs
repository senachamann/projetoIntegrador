using System.Data.SqlClient;

namespace ProjetoIntegrador.Infrastructure
{
    internal class SampleAccessDataBase
    {
        public void ExecuteSql()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "<your_server.database.windows.net>",
                UserID = "<your_username>",
                Password = "<your_password>",
                InitialCatalog = "<your_database>"
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();

                String sql = "SELECT name, collation_name FROM sys.databases";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
        }
    }
}
