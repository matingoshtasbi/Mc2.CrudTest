using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Services.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.CustomerManagement;
using Mc2.CrudTest.Infrastructure.ReadModules.Repositories.CustomerManagement;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application.DependencyInjectionExtensions
{
    public static class CustomerManagementExtension
    {
        public static IServiceCollection AddCustomerManagementModules(this IServiceCollection services)
        {
            services.AddScoped<ICustomerManagementCommandService, CustomerManagementCommandService>();
            services.AddScoped<ICustomerManagementQueryService, CustomerManagementQueryService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManagementReadRepository, CustomerManagementReadRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
