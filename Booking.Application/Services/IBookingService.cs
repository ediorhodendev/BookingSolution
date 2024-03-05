using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Application.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingModel>> GetAllBookingsAsync();
        Task<BookingModel> GetBookingByIdAsync(int id);
        Task AddBookingAsync(BookingModel booking);
        Task UpdateBookingAsync(BookingModel booking);
        Task DeleteBookingAsync(int id);
    }
}
