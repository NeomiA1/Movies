using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Movies.DAL
{
    public class DBservice
    {
        public SqlConnection Connect(string conStringName)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString(conStringName);

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        public SqlCommand CreateCommand(string storedProcedureName, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandText = storedProcedureName,
                CommandType = CommandType.StoredProcedure
            };

            return cmd;
        }
    }
}
