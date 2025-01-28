using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class CreateRentalRequest : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string VechicleId { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public DateTime? RentalDate { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public int? RentalDays { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public double? PricePerDays { get; set; }
    }
}
