using Microsoft.Data.SqlClient;
using Dapper;
using Schiavello.Contracts;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schiavello.Data
{
    public class SqlExecutionEngine : ISqlExecutionEngine
    {
        private readonly ISqlConnectionSettings _sqlConnectionSettings;
        public SqlExecutionEngine(ISqlConnectionSettings sqlConnectionSettings)
        {
            _sqlConnectionSettings = sqlConnectionSettings;
        }

        public async Task<int> ExecuteNonQueryAsync(string sqlQuery, object parameters)
        {
            try
            {
                using (var dbConnection = new SqlConnection(_sqlConnectionSettings.ConnectionString))
                {
                    dbConnection.Open();
                    var numberOfRowsAffected = await dbConnection.ExecuteAsync(sqlQuery, parameters);
                    return numberOfRowsAffected;
                }
            }
            catch (Exception ex)
            {
                var e = ex;
            }

            return 0;
        }

        public async Task<T> ExecuteScalarAsync<T>(string sqlQuery, object parameters)
        {
            using (var dbConnection = new SqlConnection(_sqlConnectionSettings.ConnectionString))
            {
                dbConnection.Open();
                var singleRow = await dbConnection.ExecuteScalarAsync<T>(sqlQuery, parameters);
                return singleRow;
            }
        }

        public async Task<IEnumerable<T>> ExecuteReaderAsync<T>(string sqlQuery, object parameters)
        {
            using (var dbConnection = new SqlConnection(_sqlConnectionSettings.ConnectionString))
            {
                dbConnection.Open();
                var items = await dbConnection.QueryAsync<T>(sqlQuery, parameters);
                return items
                    .ToList();
            }
        }
    }
}