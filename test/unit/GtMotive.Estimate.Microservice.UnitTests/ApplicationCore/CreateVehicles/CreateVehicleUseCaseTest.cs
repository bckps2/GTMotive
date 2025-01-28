using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.CreateVehicles
{
    /// <summary>
    /// Writes to the Standard Output.
    /// </summary>
    public class CreateVehicleUseCaseTest
    {
        /// <summary>
        /// Test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateUserUSeCaseAsync()
        {
            var mockPresenter = new Mock<IWebApiPresenterExtension>();
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            var mockOutputUseCase = new Mock<IOutputPortStandard<CreateVehicleResponse>>();

            var vehicle = GetVehicle();
            var request = GetCreateVehicleRequest();
            var response = GetCreateVehicleResponse();

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

        private static CreateVehicleRequest GetCreateVehicleRequest()
        {
            return new CreateVehicleRequest
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
        }

        private static CreateVehicleResponse GetCreateVehicleResponse()
        {
            return new CreateVehicleResponse
            {
                Brand = "Honda",
                Color = "red",
                Id = "1234",
                Model = "model",
            };
        }

        private static Vehicle GetVehicle()
        {
            return new Vehicle(2021)
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
        }
    }
}
