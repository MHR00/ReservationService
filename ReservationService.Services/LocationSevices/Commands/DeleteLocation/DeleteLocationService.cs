using ReservationService.Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;
using ReservationService.Entities.Places;

namespace ReservationService.Services.LocationSevices.Commands.DeleteLocation
{
    public class DeleteLocationService : IDeleteLocationService
    {
        private readonly SqlDataAccess _context;

        public DeleteLocationService(SqlDataAccess context)
        {
            _context = context;
        }

        public async Task DeleteLocation(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.DeleteAsync<Location>(new Location { Id = id });
            }
        }
    }
}
