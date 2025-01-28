using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="vehicleRepository">The injection paramter.</param>
    public class CreateVehicleUseCase(IOutputPortStandard<CreateVehicleResponse> outputPortStandard, IVehicleRepository vehicleRepository) : IUseCase<CreateVehicleRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleRequest input)
        {
            if (input != null)
            {
                var vehicle = new Vehicle(input.YearManufacture)
                {
                    YearManufacture = input.YearManufacture,
                    Color = input.Color,
                    NumberDoors = input.NumberDoors,
                    Kilometers = input.Kilometers,
                    Brand = input.Brand,
                    Model = input.Model,
                    Engine = input.Motor,
                    VehicleType = input.VehicleType
                };

                var result = await vehicleRepository.CreateVehicleAsync(vehicle);

                if (result == null)
                {
                    outputPortStandard.StandardHandle(null);
                }
                else
                {
                    var vehicleDb = await vehicleRepository.GetVehicleById(result);

                    var responseVehicle = new CreateVehicleResponse
                    {
                        Color = vehicleDb.Color,
                        Model = vehicleDb.Model,
                        Brand = vehicleDb.Brand,
                        Id = vehicleDb.Id
                    };

                    outputPortStandard.StandardHandle(responseVehicle);
                }
            }

            await Task.CompletedTask;
        }
    }
}
