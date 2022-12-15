using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Services.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.CustomerManagement;
using Mc2.CrudTest.Infrastructure.ReadModules.Repositories.CustomerManagement;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mc2.CrudTest.Application.DependencyInjectionExtensions
{
    public static class CustomerManagementExtension
    {
        public static IServiceCollection AddCustomerManagementModules(this IServiceCollection services)
        {
            services.AddTransient<ICustomerManagementCommandService, CustomerManagementCommandService>();
            services.AddTransient<ICustomerManagementQueryService, CustomerManagementQueryService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerManagementReadRepository, CustomerManagementReadRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            return services;
        }
    }
}
