using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Entities.Locations;
using ReservationService.Services.LocationSevices.Commands.AddLocation;
using ReservationService.Services.LocationSevices.Commands.DeleteLocation;
using ReservationService.Services.LocationSevices.Commands.EditLocation;
using ReservationService.Services.LocationSevices.Queries.SearchLocation;
using ReservationService.Services.LocationSevices.Queries.ShowLocation;

namespace ReservationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IAddLocationService _addLocationService;
        private readonly IEditLocationService _editLocationService;
        private readonly IDeleteLocationService _deleteLocationService;
        private readonly IShowLocationService _showLocationService;
        private readonly ISearchLocationService _searchLocationService;

        public LocationsController(IAddLocationService addLocationService,
            IEditLocationService editLocationService,
            IDeleteLocationService deleteLocationService,
            IShowLocationService showLocationService,
            ISearchLocationService searchLocationService)
        {
            _addLocationService = addLocationService;
            _editLocationService = editLocationService;
            _deleteLocationService = deleteLocationService;
            _showLocationService = showLocationService;
            _searchLocationService = searchLocationService;
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
        public async Task<IResult> EditLocation([FromQuery] int locationId ,  EditLocationDto location)
        {
            try
            {
                await _editLocationService.EditLocation(location , locationId);
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

        [HttpGet("[action]")]
        public async Task<IResult> ShowLocationList([FromQuery] int page=1 , int pageSize=4)
        {
            try
            {
                var loctionList = await _showLocationService.LocationList(page , pageSize);
                return Results.Ok(loctionList);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IResult> SearchInLocation([FromQuery] string? name , string? type , int page=1, int size=4)
        {
            try
            {
                var results =await _searchLocationService.SearchLocation(name, type, page,size);
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        
    }

}
