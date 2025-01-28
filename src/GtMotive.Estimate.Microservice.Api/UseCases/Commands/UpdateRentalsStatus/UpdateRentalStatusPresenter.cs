using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.UpdateRentalsStatus
{
    public class UpdateRentalStatusPresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<UpdateRentalStatusResponse>
    {
        public void StandardHandle(UpdateRentalStatusResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new OkObjectResult(response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
