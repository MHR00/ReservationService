using ReservationService.Entities.Places;

namespace ReservationService.Services.LocationSevices.Queries.SearchLocation
{
    public interface ISearchLocationService
    {
        Task<List<Location>> SearchLocation(string name, string location, int page);
    }
}