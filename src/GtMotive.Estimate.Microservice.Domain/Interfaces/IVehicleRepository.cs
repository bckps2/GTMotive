using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The Output Port Message.</param>
        Task<Vehicle> GetVehicleById(string id);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="vehicle">The Output Port Message.</param>
        Task<string> CreateVehicleAsync(Vehicle vehicle);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    }
}
