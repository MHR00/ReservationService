using ReservationService.Entities.Places;

namespace ReservationService.Services.LocationSevices.Queries.ShowLocation
{
    public interface IShowLocationService
    {
        Task<List<Location>> LocationList(int page);
    }
}