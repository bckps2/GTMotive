using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public string Email { get; set; }
    }
}
