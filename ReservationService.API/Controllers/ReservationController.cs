using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Services.ReservationServices;

namespace ReservationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        [HttpPost("[action]")]
        public async Task<IResult> ReservingPlace(int userId, int locationId)
        {
            try
            {
                await _reservationsService.ReservingPlace(userId, locationId);
                return Results.Ok("مکان مورد نظر با موفقیت رزرو شد");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
