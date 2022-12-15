using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;

namespace Mc2.CrudTest.Domain.CustomerManagement.Aggregates
{
    public static class CustomerFactory
    {
        public static Customer Create(CustomerPO po, ICustomerService customerService) 
        {
            var customer = new Customer(po, customerService);  

            return customer;    
        }

    }
}
