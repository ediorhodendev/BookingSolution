using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly YourDbContext _context;

        public BookingRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingModel>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<BookingModel> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task AddAsync(BookingModel booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingModel booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bookingToRemove = await _context.Bookings.FindAsync(id);
            if (bookingToRemove != null)
            {
                _context.Bookings.Remove(bookingToRemove);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Booking not found");
            }
        }
    }
}
