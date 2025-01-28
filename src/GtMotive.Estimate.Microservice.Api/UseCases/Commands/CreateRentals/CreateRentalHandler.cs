using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateRentals
{
    public class CreateRentalHandler(IUseCase<CreateRentalRequest> createRental) : IRequestHandler<CreateRentalCommand>
    {
        public async Task<Unit> Handle(CreateRentalCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var request = new CreateRentalRequest
                {
                    Email = command.Email,
                    RentalDate = command.RentalDate,
                    VechicleId = command.VechicleId,
                    PricePerDays = command.PricePerDays,
                    RentalDays = command.RentalDays,
                };

                await createRental.Execute(request);
            }

            return Unit.Value;
        }
    }
}
