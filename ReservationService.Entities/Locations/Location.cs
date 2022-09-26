using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Places
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }

        public decimal LatitudesLocation { get; set; }
        public decimal LongitudesLocation { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;


       

}
   

    


}
