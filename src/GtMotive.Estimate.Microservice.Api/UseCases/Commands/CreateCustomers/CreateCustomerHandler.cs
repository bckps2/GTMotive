using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateCustomers
{
    public class CreateCustomerHandler(IUseCase<CreateCustomerRequest> createCustomer) : IRequestHandler<CreateCustomerCommand>
    {
        public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var request = new CreateCustomerRequest
                {
                    Email = command.Email,
                    Name = command.Name,
                    Surname = command.Surname
                };

                await createCustomer.Execute(request);
            }

            return Unit.Value;
        }
    }
}
