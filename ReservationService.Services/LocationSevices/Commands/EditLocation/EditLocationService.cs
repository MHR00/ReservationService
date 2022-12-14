using ReservationService.Data.DbAccess;
using ReservationService.Entities.Locations;
using ReservationService.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.FastCrud;
using System.Threading.Tasks;

namespace ReservationService.Services.LocationSevices.Commands.EditLocation
{
    public class EditLocationService : IEditLocationService
    {
        private readonly SqlDataAccess _context;

        public EditLocationService(SqlDataAccess context)
        {
            _context = context;
        }

        public async Task EditLocation(EditLocationDto location , int locationId)
        {
            using (var connection = _context.CreateConnection())
            {
                Location locations = new()
                {
                    Id = locationId,
                    Name = location.Name,
                    Address = location.Address,
                    LocationType = location.LocationType,
                    LatitudesLocation = location.LatitudesLocation,
                    LongitudesLocation = location.LongitudesLocation,
                    Price = location.Price
                };
                await connection.UpdateAsync<Location>(locations);
            }
        }
    }
}
