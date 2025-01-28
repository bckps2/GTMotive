using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="customerRepository">The injection paramter.</param>
    public class GetCustomersUseCase(IOutputPortStandard<GetListCustomerResponse> outputPortStandard, ICustomerRepository customerRepository) : IUseCase<GetCustomersRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetCustomersRequest input)
        {
            var result = await customerRepository.GetAllCustomersAsync();

            var response = new List<GetCustomerResponse>();

            foreach (var customer in result)
            {
                var customerResponse = new GetCustomerResponse
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    Name = customer.Name,
                    Surname = customer.Surname
                };

                response.Add(customerResponse);
            }

            var responseList = new GetListCustomerResponse
            {
                Customers = response
            };

            outputPortStandard.StandardHandle(responseList);

            await Task.CompletedTask;
        }
    }
}
