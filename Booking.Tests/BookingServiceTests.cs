using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Booking.Domain.Entities;
using Booking.Infrastructure.Repositories;

namespace Booking.Tests
{
    public class BookingRepositoryTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsListOfBookings()
        {
            // Arrange
            var mockBookings = new List<BookingModel>
            {
                new BookingModel { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CustomerId = 1, VehicleId = 1 },
                new BookingModel { Id = 2, StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(3), CustomerId = 2, VehicleId = 2 },
                new BookingModel { Id = 3, StartDate = DateTime.Now.AddDays(4), EndDate = DateTime.Now.AddDays(5), CustomerId = 3, VehicleId = 3 }
            };

            var bookingRepositoryMock = new Mock<IBookingRepository>();
            bookingRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockBookings);

            // Act
            var bookings = await bookingRepositoryMock.Object.GetAllAsync();

            // Assert
            Assert.NotNull(bookings);
            //Assert.Equal(3, bookings.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBooking()
        {
            // Arrange
            int bookingId = 1;
            var bookingModel = new BookingModel { Id = bookingId, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CustomerId = 1, VehicleId = 1 };

            var bookingRepositoryMock = new Mock<IBookingRepository>();
            bookingRepositoryMock.Setup(repo => repo.GetByIdAsync(bookingId)).ReturnsAsync(bookingModel);

            // Act
            var booking = await bookingRepositoryMock.Object.GetByIdAsync(bookingId);

            // Assert
            Assert.NotNull(booking);
            Assert.Equal(bookingId, booking.Id);
        }

        [Fact]
        public async Task AddAsync_SuccessfullyAddsBooking()
        {
            // Arrange
            var bookingModel = new BookingModel { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CustomerId = 1, VehicleId = 1 };

            var bookingRepositoryMock = new Mock<IBookingRepository>();
            bookingRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<BookingModel>())).Returns(Task.CompletedTask);

            // Act
            await bookingRepositoryMock.Object.AddAsync(bookingModel);

            // Assert
            bookingRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<BookingModel>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_SuccessfullyUpdatesBooking()
        {
            // Arrange
            var bookingModel = new BookingModel { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CustomerId = 1, VehicleId = 1 };

            var bookingRepositoryMock = new Mock<IBookingRepository>();
            bookingRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<BookingModel>())).Returns(Task.CompletedTask);

            // Act
            await bookingRepositoryMock.Object.UpdateAsync(bookingModel);

            // Assert
            bookingRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<BookingModel>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_SuccessfullyDeletesBooking()
        {
            // Arrange
            int bookingId = 1;

            var bookingRepositoryMock = new Mock<IBookingRepository>();
            bookingRepositoryMock.Setup(repo => repo.DeleteAsync(bookingId)).Returns(Task.CompletedTask);

            // Act
            await bookingRepositoryMock.Object.DeleteAsync(bookingId);

            // Assert
            bookingRepositoryMock.Verify(repo => repo.DeleteAsync(bookingId), Times.Once);
        }
    }
}
