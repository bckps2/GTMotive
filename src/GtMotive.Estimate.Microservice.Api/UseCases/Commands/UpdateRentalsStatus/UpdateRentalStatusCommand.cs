using GtMotive.Estimate.Microservice.Domain.Enums;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.UpdateRentalsStatus
{
    public class UpdateRentalStatusCommand : IRequest
    {
        public string Email { get; set; }

        public RentalEstatus? Status { get; set; }
    }
}
