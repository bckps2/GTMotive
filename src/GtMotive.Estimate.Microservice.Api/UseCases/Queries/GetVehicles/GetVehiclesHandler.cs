using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetVehicles
{
    public class GetVehiclesHandler(IUseCase<GetVehiclesRequest> createVehicleUseCase) : IRequestHandler<GetVehiclesQuery>
    {
        public async Task<Unit> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            await createVehicleUseCase.Execute(new GetVehiclesRequest());
            return Unit.Value;
        }
    }
}
