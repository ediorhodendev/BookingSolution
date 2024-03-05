using System;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Infrastructure.Repositories;

namespace Booking.Api.Seed
{
    public static class SeedData
    {
        public static async Task PopulateData(IBookingRepository bookingRepository)
        {
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
