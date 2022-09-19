using Dapper;
using ReservationService.Data.DbAccess;
using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Services.UserServices.LoginUser
{
    public class LoginUserService : ILoginUserService
    {
        private readonly SqlDataAccess _context;

        public LoginUserService(SqlDataAccess context)
        {
            _context = context;
        }

        public async Task<ResultUserLoginDto> LoginUser(LoginUserDto user)
        {
            var procedureName = "spUserLogin";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", user.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", user.Password, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var userlogin = await connection.QueryFirstOrDefaultAsync<ResultUserLoginDto>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return userlogin;
            }
        }
    }
}
