using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(IWebApiPresenterExtension webApiPresenter, IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateVehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand createVehiclesCommand)
        {
            await mediator.Send(createVehiclesCommand);
            return webApiPresenter.ActionResult;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(GetListVehiclesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllVehicles()
        {
            await mediator.Send(new GetVehiclesQuery());
            return webApiPresenter.ActionResult;
        }
    }
}
