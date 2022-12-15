using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Core.DTOs;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.CustomerManagement
{
    public class CustomerManagementQueryService : ICustomerManagementQueryService
    {
        #region members
        private ICustomerManagementReadRepository _customerManagementReadRepository;
        #endregion

        #region constractors
        public CustomerManagementQueryService(ICustomerManagementReadRepository customerManagementReadRepository)
        {
            _customerManagementReadRepository = customerManagementReadRepository;
        }
        #endregion

        #region public methods
        public async Task<PageResult<CustomerVM>> FindEmployees(FindCustomerRequest request)
        {
            return await _customerManagementReadRepository.GetCustomers(request);
        }
        public async Task<CustomerVM> FindEmployee(Guid id)
        {
            return await _customerManagementReadRepository.GetCustomer(id);
        }
        #endregion
    }
}
