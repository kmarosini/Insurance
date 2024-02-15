using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PartnerWeb.DataAccess
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _conn;

        public DapperContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _conn = _iConfiguration.GetConnectionString("InsuranceDatabaseConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_conn);

    }
}