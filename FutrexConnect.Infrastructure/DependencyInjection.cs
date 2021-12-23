using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Interfaces;
using FutrexConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FutrexConnect.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("FCDb"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<CustomerAddressDetails>, Repository<CustomerAddressDetails>>();
            services.AddScoped<IRepository<CustomerContactDetails>, Repository<CustomerContactDetails>>();
            services.AddScoped<IRepository<CustomerSupportingDocuments>, Repository<CustomerSupportingDocuments>>();
            return services;
        }
    }
}