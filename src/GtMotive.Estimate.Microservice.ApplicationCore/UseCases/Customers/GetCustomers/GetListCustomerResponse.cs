using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers
{
    /// <summary>
    /// Gets or sets writes to the Standard Output.
    /// </summary>
    public class GetListCustomerResponse : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets writes to the Standard Output.
        /// </summary>
        public IEnumerable<GetCustomerResponse> Customers { get; set; }
    }
}
