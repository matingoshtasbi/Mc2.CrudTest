using Mc2.CrudTest.AcceptanceTests.BaseClasses;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerBDDStepDefinitions : BaseTestClass
    {
        #region members
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;

        CustomerPO customerPO;
        Customer customer;
        Guid customerId;
        #endregion

        #region constractor
        public CustomerBDDStepDefinitions() : base()
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
                FirstName = "Matin",
                LastName = "Goshtasbi",
                DateOfBirth = new DateTime(2000, 1, 12),
                Email = "matin.goshtasbi@gmail.com",
                PhoneNumber = "+989309756517",
                BankAccountNumber = "6037-9974-8204-1861"
            };
        }
        #endregion

        #region public methods
        [Given(@"Input Customer info")]
        public void GivenInputCustomerInfo()
        {
            customerPO = createCustomerPO();
        }

        [When(@"Customer Added to App")]
        public void WhenCustomerAddedToApp()
        {
            customer = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer);
            _customerRepository.UnitOfWork.SaveChanges();
        }

        [Then(@"App should be Show Customer Id")]
        public void ThenAppShouldBeShowCustomerId()
        {
            Assert.True(Guid.TryParse(customer.Id.ToString(), out customerId));
        }

        [Given(@"Input Customer Family For Find Customer")]
        public void GivenInputCustomerFamilyForFindCustomer()
        {
            // Customer Added
            var customerPO = createCustomerPO();
            var customer2 = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer2);
            _customerRepository.UnitOfWork.SaveChanges();

            // Find Existing Customer
            customer = _customerRepository.Get(c => c.LastName == "Goshtasbi").FirstOrDefault();
        }

        [Given(@"Input Customer new Info")]
        public void GivenInputCustomerNewInfo()
        {
            customer.LastName = "Alizade";
        }

        [When(@"Customer Updated to App")]
        public void WhenCustomerUpdatedToApp()
        {
            _customerRepository.UnitOfWork.SaveChanges();
        }

        [Then(@"App Should be Show Update Successful")]
        public void ThenAppShouldBeShowUpdateSuccessful()
        {
            customer = _customerRepository.Get(c => c.LastName == "Goshtasbi").FirstOrDefault();
            Assert.Null(customer);
        }

        [Given(@"Input Customer Name for Find Customer")]
        public void GivenInputCustomerNameForFindCustomer()
        {
            // Customer Added
            var customerPO = createCustomerPO();
            var customer2 = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer2);
            _customerRepository.UnitOfWork.SaveChanges();

            // Find Existing Customer
            customer = _customerRepository.Get(c => c.FirstName == "Matin").FirstOrDefault();
        }

        [When(@"Customer Deleted from App")]
        public void WhenCustomerDeletedFromApp()
        {
            _customerRepository.Remove(customer.Id);
        }

        [Then(@"App should be Show Delete Successful")]
        public void ThenAppShouldBeShowDeleteSuccessful()
        {
            customer = _customerRepository.Get(c => c.FirstName == "Matin").FirstOrDefault();
            Assert.Null(customer);
        }
        #endregion
    }
}
