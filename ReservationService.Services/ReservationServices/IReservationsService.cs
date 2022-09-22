namespace ReservationService.Services.ReservationServices
{
    public interface IReservationsService
    {
        Task ReservingPlace(int userId, int locationId);
    }
}