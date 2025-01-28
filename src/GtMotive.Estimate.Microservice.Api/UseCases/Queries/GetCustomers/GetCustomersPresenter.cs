using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetCustomers
{
    public class GetCustomersPresenter(IWebApiPresenterExtension webApiPresenterExtension) : IOutputPortStandard<GetListCustomerResponse>
    {
        public void StandardHandle(GetListCustomerResponse response)
        {
            IActionResult result = response == null ? new BadRequestResult() : new OkObjectResult(response);
            webApiPresenterExtension.SetActionResult(result);
        }
    }
}
