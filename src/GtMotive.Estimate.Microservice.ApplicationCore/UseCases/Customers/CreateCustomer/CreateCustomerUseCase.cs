using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="customerRepository">The injection paramter.</param>
    public class CreateCustomerUseCase(IOutputPortStandard<CreateCustomerResponse> outputPortStandard, ICustomerRepository customerRepository) : IUseCase<CreateCustomerRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(CreateCustomerRequest input)
        {
            if (input != null)
            {
                var customerByEmail = await customerRepository.GetCustomerByEmailAsync(input.Email);

                if (customerByEmail != null)
                {
                    throw new InvalidOperationException($"El cliente con el mail: {input.Email}, ya existe!");
                }

                var customer = new Customer
                {
                    Email = input.Email,
                    Name = input.Name,
                    Surname = input.Surname
                };

                var result = await customerRepository.CreateCustomerAsync(customer);

                if (result == null)
                {
                    outputPortStandard.StandardHandle(null);
                }
                else
                {
                    var customerDb = await customerRepository.GetCustomerByIdAsync(result);

                    var responseCustomer = new CreateCustomerResponse
                    {
                        Surname = customerDb.Surname,
                        Name = customerDb.Name,
                        Email = input.Email
                    };

                    outputPortStandard.StandardHandle(responseCustomer);
                }
            }
        }
    }
}
