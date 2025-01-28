using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateVehicles
{
    public class CreateVehicleCommand : IRequest
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int? FabricationYear { get; set; }

        public string Color { get; set; }

        public string Motor { get; set; }

        public int? NumberDoors { get; set; }

        public string VehicleType { get; set; }

        public int? Kilometers { get; set; }
    }
}
