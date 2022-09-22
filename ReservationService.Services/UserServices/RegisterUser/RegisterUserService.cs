using ReservationService.Data.DbAccess;
using ReservationService.Entities.Users;
using Dapper.FastCrud;
using ReservationService.Entities.Customers;

namespace ReservationService.Services.UserServices.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly SqlDataAccess _context;
        

        public RegisterUserService(SqlDataAccess context )
        {
            _context = context;
        }

        public async Task RegiterUser(RegisterUserDto user)
        {
            using (var connection = _context.CreateConnection())
            {
             
                User users = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    MobileNumber = user.MobileNumber
                    
                };
                  await connection.InsertAsync<User>(users);
            }
        }

        public async Task InsertCustomer(Customer customer)
        {
            using (var connection = _context.CreateConnection())
            {
                Customer coustomer = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                   
                };
                await connection.InsertAsync<Customer>(coustomer);
            }
        }


    }
}
