using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="rentalDate">rental date.</param>
        /// <param name="rentalDays">return date.</param>
        public Rental(DateTime? rentalDate, int? rentalDays)
        {
            ReturnDate = rentalDate.Value.AddDays(rentalDays ?? 0);
            ValidateRentalDate(rentalDate);
            ValidateReturnDate(rentalDate, ReturnDate);
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
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string VechicleId { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public int? RentalDays { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public double? PricePerDays { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public DateTime? RentalDate { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public RentalEstatus Status { get; set; }

        private static void ValidateRentalDate(DateTime? rentalDate)
        {
            if (rentalDate == null)
            {
                throw new DomainException("La fecha no puede ser null!");
            }

            if (rentalDate.Value.DayOfYear < DateTime.UtcNow.DayOfYear)
            {
                throw new DomainException("La fecha no puede ser inferior a la de hoy!");
            }
        }

        private static void ValidateReturnDate(DateTime? rentalDate, DateTime? returnDate)
        {
            if (returnDate != null && rentalDate > returnDate)
            {
                throw new DomainException("La fecha de devolucion no puede ser menor que la fecha de entrega.");
            }
        }
    }
}
