using ReservationService.Data.DbAccess;
using ReservationService.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.FastCrud;
using System.Data;
using ReservationService.Entities.Places;

namespace ReservationService.Services.LocationSevices.Commands.AddLocation
{
    public class AddLocationService : IAddLocationService
    {
        private readonly SqlDataAccess _context;

        public AddLocationService(SqlDataAccess context)
        {
            _context = context;
        }
        public async Task AddLocation(AddLocationDto location)
        {

            using (var connection = _context.CreateConnection())
            {
                Location locations = new()
                {
                    Name = location.Name,
                    LocationType = location.LocationType,
                    GeographicalLocation = location.GeographicalLocation,
                    Price = location.Price
                };
                await connection.InsertAsync(locations);
            }

        }
    }
}
