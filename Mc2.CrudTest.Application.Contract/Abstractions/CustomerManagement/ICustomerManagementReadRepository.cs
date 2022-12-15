using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement
{
    public interface ICustomerManagementReadRepository
    {
        #region customer
        Task<PageResult<CustomerVM>> GetCustomers(FindCustomerRequest request);
        Task<CustomerVM> GetCustomer(Guid id);
        #endregion
    }
}
