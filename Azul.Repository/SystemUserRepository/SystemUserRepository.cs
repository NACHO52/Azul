using Azul.Shared;
using Dapper;
using System.Data;

namespace Azul.Repository
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public SystemUserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SystemUser> Get(string username, string password)
        {
            var sql = "SELECT Id, Username, Email, [Password], [Role] FROM SystemUser WHERE Username = @username AND Password = @password";
            return await _dbConnection.QueryFirstAsync<SystemUser>(sql, new { username, password });
        }

        public async Task<IList<SystemUser>> GetAll()
        {
            var sql = "SELECT Id, Username, Email, [Password], [Role] FROM SystemUser";
            return (IList<SystemUser>)await _dbConnection.QueryAsync<SystemUser>(sql, new { });
        }
    }
}