using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Reservations
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime RegisterationTime { get; set; }
        public DateOnly ReservationDate { get; set; }
        public string ReservedPlace { get; set; }
        public decimal Price { get; set; }
        public string Resevatore { get; set; }
        
    }
}
