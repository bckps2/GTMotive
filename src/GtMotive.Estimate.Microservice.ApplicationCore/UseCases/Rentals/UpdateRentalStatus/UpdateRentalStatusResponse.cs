using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class UpdateRentalStatusResponse : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public RentalEstatus Status { get; set; }
    }
}
