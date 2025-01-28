using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="fabricationYear">FabircationYear.</param>
        public Vehicle(int? fabricationYear)
        {
            ValidateFabricationYear(fabricationYear);
        }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
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
        public int? YearManufacture { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Engine { get; set; }

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

        private static void ValidateFabricationYear(int? fabricationYear)
        {
            var olderYear = DateTime.Now.Year - fabricationYear;

            if (olderYear > 5)
            {
                throw new DomainException("Car fabrication year, is older than 5 years, can't registry");
            }
        }
    }
}
