using Dapper;
using AsynchronousDapper.DataAccess.DbAccess;
using AsynchronousDapper.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousDapper.DataAccess.Data
{
    /// <summary>
    /// Query를 통한 결과 처리
    /// </summary>
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<UserModel> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

        public Task<IEnumerable<UserModel>> GetUsersAsync() =>
            _db.LoadDataAsync<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

        public UserModel? GetUser(int id)
        {
            var results = _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetById", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<UserModel?> GetUserAsync(int id)
        {
            var results = await _db.LoadDataAsync<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetById", new { Id = id });
            return results.FirstOrDefault();
        }

        public int? InsertUser_GetId(UserModel user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { FirstName = user.FirstName, LastName = user.LastName });

            _db.SaveData(storedProcedure: "dbo.spUser_Insert", p);
            return p.Get<int>("@Id");
        }

        public async Task<int?> InsertUser_GetIdAsync(UserModel user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { FirstName = user.FirstName, LastName = user.LastName });

            await _db.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", p);
            return p.Get<int>("@Id");
        }

        public bool InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

        public Task InsertUserAsync(UserModel user) =>
            _db.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

        //user객체를 사용할려면 user의 Property 와 프로시저의 인자가 같아야 된다.
        // => 아니면 다음처럼 인자를 지정해야 한다.
        // _db.SaveData(storedProcedure: "dbo.spUser_Update", new {user.FirstName, user.LastName});
        public bool UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Update", user);

        public Task UpdateUserAsync(UserModel user) =>
            _db.SaveDataAsync(storedProcedure: "dbo.spUser_Update", user);

        public bool DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });

        public Task DeleteUserAsync(int id) =>
            _db.SaveDataAsync(storedProcedure: "dbo.spUser_Delete", new { Id = id });

    }
}
