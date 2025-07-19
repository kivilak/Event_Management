using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Event_Management.Model
{
    public sealed class DatabaseManager
    {
        private static readonly Lazy<DatabaseManager> instance = new Lazy<DatabaseManager>(() => new DatabaseManager());

        private readonly string dbString;
        private SqlConnection connection;

        private DatabaseManager()
        {
            dbString = Secret.Instance.GetURL();
            connection = new SqlConnection(dbString);
        }

        public static DatabaseManager Instance => instance.Value;

        public SqlConnection GetConnection()
        {
            if(connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public void CloseConnection()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlCommand CreateCommand(string query)
        {
            var cmd = new SqlCommand(query, GetConnection());
            return cmd;
        }
    }
}
