using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repository
{
    public class RentalRepository(MongoService mongoDbService) : IRentalRepository
    {
        private readonly IMongoCollection<Rental> rentalsCollection = mongoDbService.GetCollection<Rental>("Rentals");

        public async Task<string> CreateRentalAsync(Rental rental)
        {
            if (rental != null)
            {
                await rentalsCollection.InsertOneAsync(rental);
                return rental.Id;
            }

            return null;
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await rentalsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(string id)
        {
            return await rentalsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Rental> GetActiveRentalByCustomerEmailAsync(string email)
        {
            return await rentalsCollection
                        .Find(e =>
                            e.Email == email
                            &&
                            e.Status == RentalEstatus.Active)
                        .SingleOrDefaultAsync();
        }

        public async Task<Rental> GetActiveRentalByVehicleIdAsync(string id)
        {
            return await rentalsCollection
                        .Find(e =>
                            e.VechicleId == id
                            &&
                            e.Status == RentalEstatus.Active)
                        .SingleOrDefaultAsync();
        }

        public async Task<Rental> UpdateRentalAsync(Rental rental)
        {
            var filter = Builders<Rental>.Filter.Eq(u => u.Id, rental?.Id);
            var update = Builders<Rental>.Update
                            .Set(e => e.Status, rental?.Status);

            var options = new FindOneAndUpdateOptions<Rental>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await rentalsCollection.FindOneAndUpdateAsync(filter, update, options);
        }
    }
}
