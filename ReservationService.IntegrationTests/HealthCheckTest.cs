using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace ReservationService.IntegrationTests;

public class HealthCheckTest:IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    public HealthCheckTest(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task HealthCheck_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("/healthcheck");

        response.EnsureSuccessStatusCode();
        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
