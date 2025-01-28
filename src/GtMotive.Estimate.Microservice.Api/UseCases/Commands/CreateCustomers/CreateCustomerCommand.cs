using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateCustomers
{
    public class CreateCustomerCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
