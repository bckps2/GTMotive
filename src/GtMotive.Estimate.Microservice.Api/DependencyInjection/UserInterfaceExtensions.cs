using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateCustomers;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateRentals;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.CreateVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Commands.UpdateRentalsStatus;
using GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetCustomers;
using GtMotive.Estimate.Microservice.Api.UseCases.Queries.GetVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.CreateCustomer;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Customers.GetCustomers;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.UpdateRentalStatus;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IOutputPortStandard<CreateVehicleResponse>, CreateVehiclePresenter>();
            services.AddScoped<IOutputPortStandard<GetListVehiclesResponse>, GetVehiclesPresenter>();
            services.AddScoped<IOutputPortStandard<CreateCustomerResponse>, CreateCustomerPresenter>();
            services.AddScoped<IOutputPortStandard<GetListCustomerResponse>, GetCustomersPresenter>();
            services.AddScoped<IOutputPortStandard<CreateRentalResponse>, CreateRentalPresenter>();
            services.AddScoped<IOutputPortStandard<UpdateRentalStatusResponse>, UpdateRentalStatusPresenter>();
            services.AddScoped<IWebApiPresenterExtension, WebApiPresenter>();
            return services;
        }
    }
}
