using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ReservationService.Entities.Locations;

namespace ReservationService.Services.LocationSevices.Commands.AddLocation
{
    public interface IAddLocationService
    {
        public Task AddLocation(AddLocationDto location);
    }
}
