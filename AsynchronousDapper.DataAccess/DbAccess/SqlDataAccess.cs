using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AsynchronousDapper.DataAccess.DbAccess
{
    /// <summary>
    /// MS SQL Server 접근
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            return connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public bool SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            return connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
