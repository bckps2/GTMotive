using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api.UseCasesTest
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public class CrateVehiclesTest
    {
        /// <summary>
        /// Test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateUserAsync()
        {
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            var mockOutputUseCase = new Mock<IOutputPortStandard<CreateVehicleResponse>>();
            var mockPresenter = new Mock<IWebApiPresenterExtension>();

            var request = new CreateVehicleRequest
            {
                Brand = "Honda",
                Color = "red",
                Model = "model",
                Kilometers = 5,
                Motor = "V8",
                NumberDoors = 5,
                VehicleType = "Hybrid",
                YearManufacture = 2021
            };

            var response = new CreateVehicleResponse
            {
                Brand = "Honda",
                Color = "red",
                Id = "1234",
                Model = "model",
            };

            var vehicle = new Vehicle(2021)
            {
                Brand = "Honda",
                Color = "red",
                Model = "model",
                Kilometers = 5,
                Engine = "V8",
                NumberDoors = 5,
                VehicleType = "Hybrid",
                YearManufacture = 2021
            };

            var responseActionResult = new OkObjectResult(response);

            mockPresenter.Setup(c => c.SetActionResult(responseActionResult));
            mockPresenter.SetupGet(c => c.ActionResult).Returns(responseActionResult);
            mockVehicleRepository.Setup(c => c.CreateVehicleAsync(It.IsAny<Vehicle>()))
                .Returns(Task.FromResult(response.Id));

            mockVehicleRepository.Setup(c => c.GetVehicleById(response.Id))
                .Returns(Task.FromResult(vehicle));

            mockOutputUseCase.Setup(c => c.StandardHandle(It.IsAny<CreateVehicleResponse>()));

            var useCase = new CreateVehicleUseCase(mockOutputUseCase.Object, mockVehicleRepository.Object);

            await useCase.Execute(request);

            Assert.Equal(responseActionResult, mockPresenter.Object.ActionResult);
        }
    }
}
