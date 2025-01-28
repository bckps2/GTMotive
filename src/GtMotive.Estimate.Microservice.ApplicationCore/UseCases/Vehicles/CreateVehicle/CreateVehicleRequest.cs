namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class CreateVehicleRequest : IUseCaseInput
    {
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
        public int? YearManufacture { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Motor { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public int? NumberDoors { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public int? Kilometers { get; set; }
    }
}
