using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateRentals;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.UpdateRentalsStatus;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController(IWebApiPresenterExtension webApiPresenter, IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateRentalResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateResult([FromBody] CreateRentalCommand command)
        {
            await mediator.Send(command);
            return webApiPresenter.ActionResult;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatusRental([FromBody] UpdateRentalStatusCommand command)
        {
            await mediator.Send(command);
            return webApiPresenter.ActionResult;
        }
    }
}
