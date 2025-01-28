namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public class CreateVehicleResponse : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Color { get; set; }
    }
}
