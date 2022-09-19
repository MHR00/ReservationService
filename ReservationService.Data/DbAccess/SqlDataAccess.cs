using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Data.DbAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection()
       => new SqlConnection(_connectionString);
    }
}
