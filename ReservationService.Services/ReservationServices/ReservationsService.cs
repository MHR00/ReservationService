using ReservationService.Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ReservationService.Services.ReservationServices
{
    public class ReservationsService : IReservationsService
    {
        private readonly SqlDataAccess _context;

        public ReservationsService(SqlDataAccess context)
        {
            _context = context;
        }

        public async Task ReservingPlace(int userId, int locationId)
        {
            var procedure = "spReservations";
            var paremeters = new DynamicParameters();
            paremeters.Add("userId", userId, DbType.Int64, ParameterDirection.Input);
            paremeters.Add("locationId", locationId, DbType.Int64, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedure, paremeters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
