using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class UpdateRentalStatusRequest : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public RentalEstatus? Status { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Email { get; set; }
    }
}
