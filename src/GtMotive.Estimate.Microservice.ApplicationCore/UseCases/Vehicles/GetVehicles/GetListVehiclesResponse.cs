using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class GetListVehiclesResponse : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public IEnumerable<GetVehiclesResponse> Vehicles { get; set; }
    }
}
