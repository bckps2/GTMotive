using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="rentalRepository">The injection paramter.</param>
    /// <param name="customerRepository">The injection parameter.</param>
    public class CreateRentalUseCase(
        IOutputPortStandard<CreateRentalResponse> outputPortStandard,
        IRentalRepository rentalRepository,
        ICustomerRepository customerRepository) : IUseCase<CreateRentalRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(CreateRentalRequest input)
        {
            if (input != null)
            {
                _ = await customerRepository.GetCustomerByEmailAsync(input.Email)
                    ?? throw new InvalidOperationException("El usuario no se encuentra en el sistema");

                var customerRental = await rentalRepository.GetActiveRentalByCustomerEmailAsync(input.Email);

                if (customerRental != null)
                {
                    throw new InvalidOperationException("El mismo usuario no puede alquilar otro coche, si ya tiene un alquiler en curso");
                }

                var vehicleRental = await rentalRepository.GetActiveRentalByVehicleIdAsync(input.VechicleId);

                if (vehicleRental != null)
                {
                    throw new InvalidOperationException("Este vehiculo ya esta en uso! Selecciona otro");
                }

                var rental = new Rental(input.RentalDate, input.RentalDays)
                {
                    RentalDays = input.RentalDays,
                    Email = input.Email,
                    RentalDate = input.RentalDate,
                    Status = RentalEstatus.Active,
                    VechicleId = input.VechicleId,
                    PricePerDays = input.PricePerDays
                };

                var rentalId = await rentalRepository.CreateRentalAsync(rental);

                var rentalDb = await rentalRepository.GetRentalByIdAsync(rentalId);

                var rentalResponse = new CreateRentalResponse
                {
                    ReturnDate = rentalDb.ReturnDate,
                    RentalDate = rentalDb.RentalDate,
                    Status = rentalDb.Status,
                    Total = rentalDb.RentalDays * rentalDb.PricePerDays
                };

                outputPortStandard.StandardHandle(rentalResponse);
            }

            await Task.CompletedTask;
        }
    }
}
