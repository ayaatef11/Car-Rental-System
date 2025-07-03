using Car_Rental_System.API.Extensions.Apps;
using Car_Rental_System.API.Extensions.Services;
using Car_Rental_System.Application;
using Car_Rental_System.Infrastructure;
using Car_Rental_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPresentation();
builder.Services.AddConfigurationClasses();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
//app.ApplyMigrationsAsync<WebApplication>();
await app.SeedDataAsync();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

