using GtMotive.Estimate.Microservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="rental">The Output Port Message.</param>
        Task<string> CreateRentalAsync(Rental rental);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Rental>> GetAllRentalsAsync();

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The Output Port Message.</param>
        Task<Rental> GetRentalByIdAsync(string id);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="rental">The Output Port Message.</param>
        Task<Rental> UpdateRentalAsync(Rental rental);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The Output Port Message.</param>
        Task<Rental> GetActiveRentalByVehicleIdAsync(string id);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="email">The Output Port Message.</param>
        Task<Rental> GetActiveRentalByCustomerEmailAsync(string email);
    }
}
