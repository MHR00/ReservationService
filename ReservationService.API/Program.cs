using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using ReservationService.Common;
using ReservationService.Data.DbAccess;
using ReservationService.Services.JWT;
using ReservationService.Services.LocationSevices.Commands.AddLocation;
using ReservationService.Services.LocationSevices.Commands.DeleteLocation;
using ReservationService.Services.LocationSevices.Commands.EditLocation;
using ReservationService.Services.LocationSevices.Queries.SearchLocation;
using ReservationService.Services.LocationSevices.Queries.ShowLocation;
using ReservationService.Services.ReservationServices;
using ReservationService.Services.UserServices.LoginUser;
using ReservationService.Services.UserServices.RegisterUser;
using ReservationService.WebFremework.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<SqlDataAccess>();
builder.Services.AddSingleton<ILoginUserService, LoginUserService>();
builder.Services.AddSingleton<IRegisterUserService, RegisterUserService>();
builder.Services.AddSingleton<IAddLocationService, AddLocationService>();
builder.Services.AddSingleton<IEditLocationService, EditLocationService>();
builder.Services.AddSingleton<IDeleteLocationService, DeleteLocationService>();
builder.Services.AddSingleton<IShowLocationService, ShowLocationService>();
builder.Services.AddSingleton<ISearchLocationService, SearchLocationService>();
builder.Services.AddSingleton<IReservationsService, ReservationsService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddJwtAuthentication();
//AddAuthorization
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(nameof(SiteSettings)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservationService", Version = "1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Insert The Token !",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationService");
    });
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }