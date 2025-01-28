using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repository
{
    public class VehicleRepository(MongoService mongoDbService) : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> vehiclesCollection = mongoDbService.GetCollection<Vehicle>("Vehicles");

        public async Task<string> CreateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                await vehiclesCollection.InsertOneAsync(vehicle);
                return vehicle.Id;
            }

            return null;
        }

        public async Task<Vehicle> GetVehicleById(string id)
        {
            return await vehiclesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await vehiclesCollection.Find(_ => true).ToListAsync();
        }
    }
}
