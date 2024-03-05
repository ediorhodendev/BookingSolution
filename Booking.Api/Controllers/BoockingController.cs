using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;
using Booking.Application.Services;
using Booking.Infrastructure.Repositories;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        private readonly IBookingRepository _bookingRepository;

        // Injeção de dependência dos serviços e repositório necessários
        public BookingController(IBookingService bookingService, IVehicleService vehicleService, ICustomerService customerService, IBookingRepository bookingRepository)
        {
            _bookingService = bookingService;
            _vehicleService = vehicleService;
            _customerService = customerService;
            _bookingRepository = bookingRepository;
        }

        // Endpoint para obter todas as reservas
        [HttpGet]
        public async Task<IEnumerable<BookingModel>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            foreach (var booking in bookings)
            {
                // Obter informações completas do cliente
                booking.Customer = await _customerService.GetCustomerByIdAsync(booking.CustomerId);

                // Obter informações completas do veículo
                booking.Vehicle = await _vehicleService.GetVehicleByIdAsync(booking.VehicleId);
            }
            return bookings;
        }

        // Endpoint para obter uma reserva pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            // Obtenha o cliente completo
            var customer = await _customerService.GetCustomerByIdAsync(booking.CustomerId);
            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Obtenha o veículo completo
            var vehicle = await _vehicleService.GetVehicleByIdAsync(booking.VehicleId);
            if (vehicle == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            // Atribua o cliente e o veículo à reserva antes de retornar
            booking.Customer = customer;
            booking.Vehicle = vehicle;

            return Ok(booking);
        }

        // Endpoint para adicionar uma nova reserva
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingModel booking)
        {
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }

        // Endpoint para atualizar uma reserva existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingModel booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            try
            {
                await _bookingService.UpdateBookingAsync(booking);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Endpoint para excluir uma reserva existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
