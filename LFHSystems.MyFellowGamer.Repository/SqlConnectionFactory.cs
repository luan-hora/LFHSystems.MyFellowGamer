using LFHSystems.MyFellowGamer.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        IConfiguration _configuration;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ConnString()
        {
            return new SqlConnection(_configuration.GetConnectionString("MyFellowGamerConnString"));
        }
    }
}
