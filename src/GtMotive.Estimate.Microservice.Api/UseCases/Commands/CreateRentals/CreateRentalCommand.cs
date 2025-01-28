using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateRentals
{
    public class CreateRentalCommand : IRequest
    {
        public string Email { get; set; }

        public string VechicleId { get; set; }

        public DateTime? RentalDate { get; set; }

        public int? RentalDays { get; set; }

        public double? PricePerDays { get; set; }
    }
}
