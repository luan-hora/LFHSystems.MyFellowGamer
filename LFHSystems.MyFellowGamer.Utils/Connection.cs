using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LFHSystems.MyFellowGamer.Utils
{
    public class Connection
    {
        private IConfiguration _config;
        public Connection(IConfiguration config)
        {
            this._config = config;
        }

        public SqlConnection GetConnString(string pConnectionString = "ConnString")
        {
            SqlConnection conn = null;

            string connString = ConfigurationManager.ConnectionStrings[pConnectionString].ConnectionString;

            if (!string.IsNullOrEmpty(connString))
                conn = new SqlConnection(connString);

            return conn;
        }
    }
}
