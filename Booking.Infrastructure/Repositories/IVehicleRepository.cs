﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Infrastructure.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetByIdAsync(int id);
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAsync(int id);
    }
}
