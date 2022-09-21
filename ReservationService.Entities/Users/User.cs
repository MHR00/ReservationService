using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Users
{
    public class User
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
