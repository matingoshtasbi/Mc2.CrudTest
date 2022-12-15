using Mc2.CrudTest.AcceptanceTests.BaseClasses;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests : BaseTestClass
    {
        #region members
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        #endregion

        #region constractor
        public BddTddTests() : base()
        {
            _customerService = (ICustomerService)ServiceProvider.GetService(typeof(ICustomerService));
            _customerRepository = (ICustomerRepository)ServiceProvider.GetService(typeof(ICustomerRepository));
        }
        #endregion

        #region private methods
        private CustomerPO createCustomerPO()
        {
            return new CustomerPO
            {
            };

        }
        #endregion

        #region public methods
        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            // Todo: Refer to readme.md 
        }
        #endregion

        // Please create more tests based on project requirements as per in readme.md
    }
}
