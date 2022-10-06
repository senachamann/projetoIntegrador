using System.Data.SqlClient;

namespace ProjetoIntegrador.Infrastructure
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Logon { get; set; }
        public string Password { get; set; }
    }

   

    public class SampleAccessDataBase
    {
        public List<User> ExecuteSql(string sqlQuery, string SqlConnection)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(SqlConnection);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();

               //
               //
               //
               var users = new List<User>();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userId = Guid.Parse(reader.GetString(0));
                            var userName = reader.GetString(1);
                            var logon = reader.GetString(2);
                            var password = reader.GetString(3);
                            users.Add(new User()
                            {
                                Id = userId,
                                UserName = userName,
                                Logon = logon,
                                Password = password
                            });

                        }
                    }
                }
                return users;
            }


        }
    }
}
