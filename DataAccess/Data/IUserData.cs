using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserData
    {
        bool DeleteUser(int id);
        Task DeleteUserAsync(int id);
        UserModel? GetUser(int id);
        Task<UserModel?> GetUserAsync(int id);
        List<UserModel> GetUsers();
        Task<IEnumerable<UserModel>> GetUsersAsync();
        bool InsertUser(UserModel user);
        Task InsertUserAsync(UserModel user);
        int? InsertUser_GetId(UserModel user);
        Task<int?> InsertUser_GetIdAsync(UserModel user);
        bool UpdateUser(UserModel user);
        Task UpdateUserAsync(UserModel user);
    }
}