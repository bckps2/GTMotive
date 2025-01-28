using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateRentals
{
    public class CreateRentalPresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<CreateRentalResponse>
    {
        public void StandardHandle(CreateRentalResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new CreatedResult("CreateRental", response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
