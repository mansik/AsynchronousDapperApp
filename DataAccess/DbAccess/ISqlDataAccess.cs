namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        bool SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}