using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using ReservationService.Entities.Places;

namespace ReservationService.IntegrationTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsControllerTests : ControllerBase, IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public LocationsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateDefaultClient(new Uri("http://localhost/api/Locations/"));

        }

        [Fact]
        public async Task ShowLocationList_ReturnSuccessStatusCode()
        {
            var response = await _client.GetAsync("ShowLocationList?page=2");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task SearchInLocation_RerurnSuccessStatusCode()
        {
            var response = await _client.GetAsync("SearchInLocation?name=name%202&type=type%202&page=1&size=4");

            response.EnsureSuccessStatusCode();
        }

        //[Fact]
        //public async Task AddLocation_ReturnLoaction()
        //{
        //    //Arrange 
        //    var postRequest = new HttpRequestMessage(HttpMethod.Post, "Locations/AddLocation");
        //    var createdlocation = new Dictionary<string,string>
        //    {
        //        { "Name" , "name 1"},
        //        {"Address" , "address 1" },
        //        {"LocationType" , "type 1" },
        //        {"LatitudesLocation" , "20.232" },
        //        {"LongitudesLocation" , "10.234" },
        //        {"Price" , "10" }

        //    };
        //    postRequest.Content = new FormUrlEncodedContent(createdlocation);

        //    var response = await _client.SendAsync(postRequest);
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();

        //    Assert.Contains("name 1", responseString);
        //    Assert.Contains("address 1", responseString);

        //}

       
    }
}
