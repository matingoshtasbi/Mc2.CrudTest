using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement
{
    public interface ICustomerManagementCommandService
    {
        #region customer
        Task<Guid> AddCustomer(CustomerRequest request);
        Task UpdateCustomer(CustomerRequest request);
        Task RemoveCustomer(Guid customerId);

        #endregion
    }
}
