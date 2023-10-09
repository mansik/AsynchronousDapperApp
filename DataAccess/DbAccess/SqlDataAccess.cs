using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess
{
    /// <summary>
    /// MS SQL Server 접근
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);            
        }
    }
}
