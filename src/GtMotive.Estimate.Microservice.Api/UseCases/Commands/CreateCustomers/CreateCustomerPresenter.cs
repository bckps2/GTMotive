using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateCustomers
{
    public sealed class CreateCustomerPresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<CreateCustomerResponse>
    {
        public void StandardHandle(CreateCustomerResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new CreatedResult("CreateCustomer", response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
