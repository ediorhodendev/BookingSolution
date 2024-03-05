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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database context
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "BookingDb"));

// Register repositories and services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORS middleware to allow requests from Angular app
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200") // Allow requests from Angular app
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Seed data on application start
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<YourDbContext>();
    SeedData.PopulateData(new BookingRepository(dbContext));
}

app.MapControllers();

app.Run();
