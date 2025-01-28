using GtMotive.Estimate.Microservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="customer">The Output Port Message.</param>
        Task<string> CreateCustomerAsync(Customer customer);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The Output Port Message.</param>
        Task<Customer> GetCustomerByIdAsync(string id);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="email">The Output Port Message.</param>
        Task<Customer> GetCustomerByEmailAsync(string email);

        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
