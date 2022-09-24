using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Common.Utilities;
using ReservationService.Entities.Reservations;
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
        public async Task<IResult> ReservingPlace(ReservingPlaceDto information)
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                await _reservationsService.ReservingPlace(information , userId);
                return Results.Ok("مکان مورد نظر با موفقیت رزرو شد");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
