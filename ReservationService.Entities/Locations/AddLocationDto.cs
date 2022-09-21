﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Locations
{
    public class AddLocationDto
    {
        public string Name { get; set; }
        public string LocationType { get; set; }
        public string GeographicalLocation { get; set; }
    }
}