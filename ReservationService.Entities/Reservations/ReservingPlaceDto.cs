using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Reservations
{
    public class ReservingPlaceDto
    {
       
        public int LocationId { get; set; }
        public string ReservationDate { get; set; }
    }
}
