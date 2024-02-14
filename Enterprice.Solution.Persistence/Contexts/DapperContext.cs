using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Enterprice.Solution.Persistence.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("NorthwindConnection");
        }

        //public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
