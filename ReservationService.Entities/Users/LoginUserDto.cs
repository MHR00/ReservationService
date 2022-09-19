using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Entities.Users
{
    public class LoginUserDto
    {
       
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
      
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
