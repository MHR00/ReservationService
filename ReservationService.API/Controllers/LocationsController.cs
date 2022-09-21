using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Entities.Locations;
using ReservationService.Services.LocationSevices.Commands.AddLocation;
using ReservationService.Services.LocationSevices.Commands.DeleteLocation;
using ReservationService.Services.LocationSevices.Commands.EditLocation;

namespace ReservationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IAddLocationService _addLocationService;
        private readonly IEditLocationService _editLocationService;
        private readonly IDeleteLocationService _deleteLocationService;

        public LocationsController(IAddLocationService addLocationService,
            IEditLocationService editLocationService,
            IDeleteLocationService deleteLocationService)
        {
            _addLocationService = addLocationService;
            _editLocationService = editLocationService;
            _deleteLocationService = deleteLocationService;
        }

        [HttpPost("[action]")]
        public async Task<IResult> AddLocation(AddLocationDto location)
        {
            try
            {
                await _addLocationService.AddLocation(location);
                return Results.Ok("مکان جدید اضافه شد");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IResult> EditLocation(EditLocationDto location)
        {
            try
            {
                await _editLocationService.EditLocation(location);
                return Results.Ok("مکان مورد نظر ویرایش شد ");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IResult> DeleteLocation(int id)
        {
            try
            {
                await _deleteLocationService.DeleteLocation(id);
                return Results.Ok("مکان مورد نظر با موفعیت حذف گردید");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        
    }

}
