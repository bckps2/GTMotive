using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetCustomers
{
    public class GetCustomersHandler(IUseCase<GetCustomersRequest> getCustomersUseCase) : IRequestHandler<GetCustomersQuery>
    {
        public async Task<Unit> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            await getCustomersUseCase.Execute(new GetCustomersRequest());
            return Unit.Value;
        }
    }
}
