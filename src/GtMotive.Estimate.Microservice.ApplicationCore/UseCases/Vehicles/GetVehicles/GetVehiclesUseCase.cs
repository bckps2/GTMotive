using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    /// <param name="outputPortStandard">The Output Port Message.</param>
    /// <param name="vehicleRepository">The injection paramter.</param>
    public class GetVehiclesUseCase(IOutputPortStandard<GetListVehiclesResponse> outputPortStandard, IVehicleRepository vehicleRepository) : IUseCase<GetVehiclesRequest>
    {
        /// <summary>
        /// Writes to the Standard Output.
        /// </summary>
        /// <param name="input">The Output Port Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetVehiclesRequest input)
        {
            var result = await vehicleRepository.GetAllVehiclesAsync();

            var response = new List<GetVehiclesResponse>();

            foreach (var vehicle in result)
            {
                var vehicleResponse = new GetVehiclesResponse
                {
                    Id = vehicle.Id,
                    Color = vehicle.Color,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model
                };

                response.Add(vehicleResponse);
            }

            var responseList = new GetListVehiclesResponse
            {
                Vehicles = response
            };

            outputPortStandard.StandardHandle(responseList);

            await Task.CompletedTask;
        }
    }
}
