using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="rentalRepository">The injection paramter.</param>
    public class UpdateRentalStatusUseCase(
        IOutputPortStandard<UpdateRentalStatusResponse> outputPortStandard,
        IRentalRepository rentalRepository) : IUseCase<UpdateRentalStatusRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(UpdateRentalStatusRequest input)
        {
            if (input != null)
            {
                var rentalByCustomer = await rentalRepository.GetActiveRentalByCustomerEmailAsync(input.Email)
                    ?? throw new InvalidOperationException($"No hay un alquiler asociado al usuario: {input.Email}");

                rentalByCustomer.Status = input.Status.Value;

                var updateRental = await rentalRepository.UpdateRentalAsync(rentalByCustomer);

                var response = new UpdateRentalStatusResponse
                {
                    Status = updateRental.Status
                };

                outputPortStandard.StandardHandle(response);
            }

            await Task.CompletedTask;
        }
    }
}
