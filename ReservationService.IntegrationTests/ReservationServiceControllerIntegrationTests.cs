using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ReservationService.Data.DbAccess;

namespace ReservationService.IntegrationTests;

public class ReservationServiceControllerIntegrationTests<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    //protected override void ConfigureWebHost(IWebHostBuilder builder)
    //{
    //    builder.ConfigureServices(services =>
    //    {
    //        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(<SqlDataAccess>));
    //    });
    //}

}