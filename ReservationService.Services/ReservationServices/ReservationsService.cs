using ReservationService.Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using ReservationService.Entities.Reservations;

namespace ReservationService.Services.ReservationServices
{
    public class ReservationsService : IReservationsService
    {
        private readonly SqlDataAccess _context;

        public ReservationsService(SqlDataAccess context)
        {
            _context = context;
        }

        public async Task ReservingPlace(ReservingPlaceDto information , int userId)
        {
            var procedure = "spReservations";
            var paremeters = new DynamicParameters();
            paremeters.Add("userId", userId, DbType.Int64, ParameterDirection.Input);
            paremeters.Add("locationId", information.LocationId, DbType.Int64, ParameterDirection.Input);
            paremeters.Add("reservationDate", information.ReservationDate, DbType.Date, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedure, paremeters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
