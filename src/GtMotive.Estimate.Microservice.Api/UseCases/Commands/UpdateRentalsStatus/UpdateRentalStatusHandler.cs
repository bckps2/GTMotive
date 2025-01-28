using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.UpdateRentalsStatus
{
    public class UpdateRentalStatusHandler(IUseCase<UpdateRentalStatusRequest> updateRentalStatus) : IRequestHandler<UpdateRentalStatusCommand>
    {
        public async Task<Unit> Handle(UpdateRentalStatusCommand command, CancellationToken cancellationToken)
        {
            var request = new UpdateRentalStatusRequest
            {
                Email = command?.Email,
                Status = command?.Status
            };

            await updateRentalStatus.Execute(request);

            return Unit.Value;
        }
    }
}
