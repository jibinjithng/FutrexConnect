using FutrexConnect.Core.Services;
using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FutrexConnect.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomer, CustomerService>();
            return services;
        }
    }
}