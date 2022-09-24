using ReservationService.Entities.Locations;

namespace ReservationService.Services.LocationSevices.Commands.EditLocation
{
    public interface IEditLocationService
    {
        Task EditLocation(EditLocationDto location, int locationId);
    }
}