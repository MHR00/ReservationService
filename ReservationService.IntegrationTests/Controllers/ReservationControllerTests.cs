using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ReservationService.IntegrationTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationControllerTests : ControllerBase, IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public ReservationControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateDefaultClient(new Uri("http://localhost/api/Reservation/"));
        }


    }
}
