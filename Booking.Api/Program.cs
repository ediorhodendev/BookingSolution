using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Booking.Domain.Entities;
using Booking.Infrastructure;
using Booking.Infrastructure.Repositories;
using Booking.Api.Seed;
using Booking.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar contexto do banco de dados
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "BookingDb"));

// Registrar reposit�rios e servi�os
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>(); // Registrar IVehicleRepository e sua implementa��o
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

// Configurar pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adicionar middleware CORS para permitir solicita��es do aplicativo Angular
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200") // Permitir solicita��es do aplicativo Angular
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Semente de dados no in�cio da aplica��o
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<YourDbContext>();
    var bookingRepository = services.GetRequiredService<IBookingRepository>();
    var customerRepository = services.GetRequiredService<ICustomerRepository>();
    var vehicleRepository = services.GetRequiredService<IVehicleRepository>();

    SeedData.PopulateData(bookingRepository, customerRepository, vehicleRepository);
}

app.MapControllers();

app.Run();
