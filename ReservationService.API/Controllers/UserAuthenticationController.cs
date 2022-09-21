using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Common.Utilities;
using ReservationService.Entities.Customers;
using ReservationService.Entities.Users;
using ReservationService.Services.JWT;
using ReservationService.Services.UserServices.LoginUser;
using ReservationService.Services.UserServices.RegisterUser;

namespace ReservationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly ILoginUserService _loginUserService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IJwtService _jwtService;

        public UserAuthenticationController(ILoginUserService loginUserService,
            IRegisterUserService registerUserService,
            IJwtService jwtService)
        {
            _loginUserService = loginUserService;
            _registerUserService = registerUserService;
            _jwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IResult> RegisterUser(RegisterUserDto user)
        {
            try
            {
                if (MobileNumberRegex.IsValidPhone(user.MobileNumber))
                {
                    var passwordHash = SecurityHelper.GetSha256Hash(user.Password);
                    user.Password = passwordHash;
                    await _registerUserService.RegiterUser(user);
                    return Results.Ok("ثبت نام شما با موفعیت انجام شد");
                }
                else return Results.BadRequest("شماره موبایل وارد شده نادرست می باشد ");
              
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IResult> InsertCoustomer(Customer customer)
        {
            try
            {
                
                    await _registerUserService.InsertCustomer(customer);
                    return Results.Ok();
                
               
            }
            catch (Exception ex )
            {

                return Results.Problem(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IResult> LoginUser([FromQuery] LoginUserDto user)
        {
            try
            {
                var passwordHash = SecurityHelper.GetSha256Hash(user.Password);
                var users = await _loginUserService.LoginUser(user);
                if(users.Password == passwordHash)
                {
                    var jwt = _jwtService.Generate(users);
                    return Results.Ok(jwt);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch (Exception ex)
            {

                return Results.Problem( ex.Message);
            }
        }

       
        [HttpGet]
        public string sayhellowworld()
        {
            return "hello world";
        }
    }
}
