using ReservationService.Entities.Reservations;

namespace ReservationService.Services.ReservationServices
{
    public interface IReservationsService
    {
        Task ReservingPlace(ReservingPlaceDto information , int userId );
    }
}