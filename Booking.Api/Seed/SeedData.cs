using System;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Infrastructure.Repositories;

namespace Booking.Api.Seed
{
    public static class SeedData
    {
        private static readonly string[] VehicleModels = { "Opala", "Gol", "Nivus", "Fox", "HB20", "Onix" };
        private static readonly string[] CustomerNames = { "Rafael Silva", "Thiago Oliveira", "Mariana Rodrigues", "Ana Souza", "Pedro Santos", "Juliana Lima" };

        public static async Task PopulateData(IBookingRepository bookingRepository,
                                              ICustomerRepository customerRepository,
                                              IVehicleRepository vehicleRepository)
        {
            // Popula clientes
            for (int i = 0; i < 10; i++)
            {
                var nameIndex = i % CustomerNames.Length; // Alternar entre os nomes definidos
                var customer = new Customer
                {
                    Name = CustomerNames[nameIndex],
                    Email = $"customer{i + 1}@example.com",
                    PhoneNumber = $"12345678{i + 1}"
                };

                await customerRepository.AddAsync(customer);
            }

            // Popula veículos
            for (int i = 0; i < 10; i++)
            {
                var modelIndex = i % VehicleModels.Length; // Alternar entre os modelos definidos
                var vehicle = new Vehicle
                {
                    Make = $"Make {i + 1}",
                    Model = VehicleModels[modelIndex],
                    Year = $"202{1 + i}",
                    RegistrationNumber = $"ABC123{i + 1}"
                };

                await vehicleRepository.AddAsync(vehicle);
            }

            // Popula reservas
            for (int i = 0; i < 10; i++)
            {
                var booking = new BookingModel
                {
                    StartDate = DateTime.Now.AddDays(i),
                    EndDate = DateTime.Now.AddDays(i + 1),
                    CustomerId = i + 1,
                    VehicleId = i + 1,
                    RatingStatus = i % 2 == 0,
                    CommentStatus = i % 2 == 0
                };

                await bookingRepository.AddAsync(booking);
            }
        }
    }
}
