using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class CreateRentalResponse : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public RentalEstatus Status { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public DateTime? RentalDate { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public DateTime? ReturnDate { get; set; }
    }
}
