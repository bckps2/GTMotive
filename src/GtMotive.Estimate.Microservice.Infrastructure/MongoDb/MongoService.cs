using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        private readonly IMongoDatabase database;

        public MongoService(IOptions<MongoDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            database = mongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            RegisterClassMap();
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }

        private static void RegisterClassMap()
        {
            BsonClassMap.RegisterClassMap<Vehicle>(classMap =>
            {
                classMap.MapMember(c => c.Kilometers);
                classMap.MapMember(c => c.NumberDoors);
                classMap.MapMember(c => c.Brand);
                classMap.MapMember(c => c.YearManufacture);
                classMap.MapMember(c => c.Color);
                classMap.MapMember(c => c.Model);
                classMap.MapMember(c => c.Engine);
                classMap.MapMember(c => c.VehicleType);
                classMap.MapIdMember(c => c.Id)
                .SetIdGenerator(MongoDB.Bson.Serialization.IdGenerators.StringObjectIdGenerator.Instance)
                .SetSerializer(new MongoDB.Bson.Serialization.Serializers.StringSerializer(MongoDB.Bson.BsonType.ObjectId));
            });

            BsonClassMap.RegisterClassMap<Customer>(classMap =>
            {
                classMap.MapMember(c => c.Surname);
                classMap.MapMember(c => c.Name);
                classMap.MapMember(c => c.Email);
                classMap.MapIdMember(c => c.Id)
                .SetIdGenerator(MongoDB.Bson.Serialization.IdGenerators.StringObjectIdGenerator.Instance)
                .SetSerializer(new MongoDB.Bson.Serialization.Serializers.StringSerializer(MongoDB.Bson.BsonType.ObjectId));
            });

            BsonClassMap.RegisterClassMap<Rental>(classMap =>
            {
                classMap.MapMember(c => c.ReturnDate);
                classMap.MapMember(c => c.Status);
                classMap.MapMember(c => c.RentalDate);
                classMap.MapMember(c => c.Email);
                classMap.MapMember(c => c.VechicleId);
                classMap.MapIdMember(c => c.Id)
                .SetIdGenerator(MongoDB.Bson.Serialization.IdGenerators.StringObjectIdGenerator.Instance)
                .SetSerializer(new MongoDB.Bson.Serialization.Serializers.StringSerializer(MongoDB.Bson.BsonType.ObjectId));
            });
        }
    }
}
