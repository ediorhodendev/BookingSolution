using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string RegistrationNumber { get; set; }

        // Relacionamento com Booking
       // public virtual ICollection<BookingModel> Bookings { get; set; }
    }

}
