using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ReservationService.IntegrationTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public UserAuthenticationControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateDefaultClient(new Uri("http://localhost/api/UserAuthentication/"));
        }
        [Fact]
        public async Task LoginUser_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("LoginUser?UserName=hossein&Password=hossein%403274");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task LoginUser_ReturnExeptedMediaType()
        {
            var response = await _client.GetAsync("LoginUser?UserName=hossein&Password=hossein%403274");

            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task LoginUser_ReturnContext()
        {
            var response = await _client.GetAsync("LoginUser?UserName=hossein&Password=hossein%403274");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0);
        }

        [Fact]
        public async Task SingInTest()
        {

            string userName = "foo";
            string password = "bar";

            var body = new JsonContent(new { userName, password });
            var response = await _client.PostAsync("RegisterUser" , body);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }



    }
}
