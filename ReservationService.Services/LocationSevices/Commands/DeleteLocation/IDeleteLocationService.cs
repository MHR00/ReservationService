namespace ReservationService.Services.LocationSevices.Commands.DeleteLocation
{
    public interface IDeleteLocationService
    {
        Task DeleteLocation(int id);
    }
}