using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetVehicles
{
    public sealed class GetVehiclesPresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<GetListVehiclesResponse>
    {
        public void StandardHandle(GetListVehiclesResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new OkObjectResult(response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
