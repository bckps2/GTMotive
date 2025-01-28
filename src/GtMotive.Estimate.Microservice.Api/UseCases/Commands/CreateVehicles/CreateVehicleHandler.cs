using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateVehicles
{
    public class CreateVehicleHandler(IUseCase<CreateVehicleRequest> createVehicleUseCase) : IRequestHandler<CreateVehicleCommand>
    {
        public async Task<Unit> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var request = new CreateVehicleRequest
                {
                    Color = command.Color,
                    NumberDoors = command.NumberDoors,
                    YearManufacture = command.FabricationYear,
                    Kilometers = command.Kilometers,
                    Brand = command.Brand,
                    Model = command.Model,
                    Motor = command.Motor,
                    VehicleType = command.VehicleType
                };

                await createVehicleUseCase.Execute(request);
            }

            return Unit.Value;
        }
    }
}
