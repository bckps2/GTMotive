using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateCustomers;
using GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetCustomers;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(IWebApiPresenterExtension webApiPresenter, IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomer)
        {
            await mediator.Send(createCustomer);
            return webApiPresenter.ActionResult;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(GetListCustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomers()
        {
            await mediator.Send(new GetCustomersQuery());
            return webApiPresenter.ActionResult;
        }
    }
}
