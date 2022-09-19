using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Services.UserServices.LoginUser
{
    public interface ILoginUserService
    {
        public Task<ResultUserLoginDto> LoginUser(LoginUserDto user);
    }
}
