using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
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

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetById", new { Id = id });
            return results.FirstOrDefault();
        }

        //public Task<int> InsertUserAndGetId(UserModel user)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //    p.AddDynamicParams(new { FullName = user.FirstName, LastName = user.LastName });
            
        //    _db.SaveData(storedProcedure: "dbo.spUser_Insert", p);
        //    return p.Get<int>("@Id");            
        //}

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Update", user);

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });
    }
}
