using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string LocationType { get; set; }
        public string GeographicalLocation { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterTime { get; set; }= DateTime.Now;

    }
}
