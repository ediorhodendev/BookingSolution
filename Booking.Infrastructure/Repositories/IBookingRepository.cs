using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Infrastructure.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingModel>> GetAllAsync();
        Task<BookingModel> GetByIdAsync(int id);

        Task AddAsync(BookingModel booking);
        Task UpdateAsync(BookingModel booking);
        Task DeleteAsync(int id);
    }
}
