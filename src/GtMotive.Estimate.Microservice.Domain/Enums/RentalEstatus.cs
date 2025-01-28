using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Enums
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RentalEstatus
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        Active = 0,

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        Finalized = 1,

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        Cancelled = 2
    }
}
