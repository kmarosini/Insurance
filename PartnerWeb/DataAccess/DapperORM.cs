using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PartnerWeb.DataAccess
{
    public static class DapperORM
    {
        private static readonly string _conn = ConfigurationManager.ConnectionStrings["InsuranceDatabaseConnection"].ConnectionString;
        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using(SqlConnection sqlCon = new SqlConnection(_conn))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(_conn))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(_conn))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}