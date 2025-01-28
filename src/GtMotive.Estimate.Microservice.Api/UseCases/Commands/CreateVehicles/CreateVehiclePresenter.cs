using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateVehicles
{
    public class CreateVehiclePresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<CreateVehicleResponse>
    {
        public void StandardHandle(CreateVehicleResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new CreatedResult("CreateVehicle", response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
