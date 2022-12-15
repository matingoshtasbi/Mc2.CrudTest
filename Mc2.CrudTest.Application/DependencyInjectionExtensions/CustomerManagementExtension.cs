using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application.DependencyInjectionExtensions
{
    public static class CustomerManagementExtension
    {
        public static IServiceCollection AddCustomerManagementModules(this IServiceCollection services)
        {
            return services;
        }
    }
}
