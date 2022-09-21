using ReservationService.Entities.Customers;
using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Services.UserServices.RegisterUser
{
    public interface IRegisterUserService
    {
        public Task RegiterUser(RegisterUserDto user);
      
        Task InsertCustomer(Customer customer);

    }
}
