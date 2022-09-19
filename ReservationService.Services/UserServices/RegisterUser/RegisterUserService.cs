using ReservationService.Data.DbAccess;
using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ReservationService.Services.UserServices.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly SqlDataAccess _context;

        public RegisterUserService(SqlDataAccess context)
        {
            _context = context;
        }
        public async Task RegiterUser(RegisterUserDto user)
        {
            var query = "INSERT INTO Users (UserName , Password,MobileNumber) VALUES (@UserName , @Password , @MobileNumber)";
               
            var parameters = new DynamicParameters();
            parameters.Add("UserName", user.UserName, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("MobileNumber", user.MobileNumber, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
