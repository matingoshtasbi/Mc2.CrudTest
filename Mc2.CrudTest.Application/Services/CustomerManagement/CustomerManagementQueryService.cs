using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;

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
        #endregion
    }
}
