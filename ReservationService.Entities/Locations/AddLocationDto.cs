

namespace ReservationService.Entities.Locations
{
    public class AddLocationDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }
        public decimal LatitudesLocation { get; set; }
        public decimal LongitudesLocation { get; set; }
        public decimal Price { get; set; }
    }
}
