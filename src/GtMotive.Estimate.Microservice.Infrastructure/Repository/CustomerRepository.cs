using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repository
{
    public class CustomerRepository(MongoService mongoDbService) : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> customersCollection = mongoDbService.GetCollection<Customer>("Customers");

        public async Task<string> CreateCustomerAsync(Customer customer)
        {
            if (customer != null)
            {
                await customersCollection.InsertOneAsync(customer);
                return customer.Id;
            }

            return null;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            return await customersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await customersCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await customersCollection.Find(x => true).ToListAsync();
        }
    }
}
