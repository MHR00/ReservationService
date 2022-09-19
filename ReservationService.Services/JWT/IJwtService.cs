using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Services.JWT
{
    public interface IJwtService
    {
        string Generate(ResultUserLoginDto users);
    }
}
