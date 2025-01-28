using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<GetVehiclesRequest>, GetVehiclesUseCase>();
            services.AddScoped<IUseCase<GetCustomersRequest>, GetCustomersUseCase>();
            services.AddScoped<IUseCase<CreateRentalRequest>, CreateRentalUseCase>();
            services.AddScoped<IUseCase<CreateVehicleRequest>, CreateVehicleUseCase>();
            services.AddScoped<IUseCase<CreateCustomerRequest>, CreateCustomerUseCase>();
            services.AddScoped<IUseCase<UpdateRentalStatusRequest>, UpdateRentalStatusUseCase>();

            return services;
        }
    }
}
