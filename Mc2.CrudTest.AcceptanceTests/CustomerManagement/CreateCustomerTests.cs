using Mc2.CrudTest.AcceptanceTests.BaseClasses;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.Exceptions;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests : BaseTestClass
    {
        #region members
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;
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
                FirstName = "Matin",
                LastName = "Goshtasbi",
                DateOfBirth = new DateTime(2000, 1, 12),
                Email = "matin.goshtasbi@gmail.com",
                PhoneNumber = "+989309756517",
                BankAccountNumber = 6037997482041861
            };
        }
        #endregion

        #region public methods

        #region TDD
        [Fact]
        public void ErrorIfFirstNameIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.FirstName = "";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfLastNameIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.LastName = "";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfDateOfBirthIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.DateOfBirth = new DateTime();
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfPhoneNumberIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.PhoneNumber = "";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfEmailIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.Email = "";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfBankAccountNumberIsEmpty()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.BankAccountNumber = 0;
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfFirstNameAndLastNameAndDateOfBirthIsExist()
        {
            CustomerPO customerPO = createCustomerPO();
            var customer = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer);
            _customerRepository.UnitOfWork.SaveChanges();

            CustomerPO customerPO2 = createCustomerPO();
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO2, _customerService));
        }

        [Fact]
        public void ErrorIfEmailIsExist()
        {
            CustomerPO customerPO = createCustomerPO();
            var customer = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer);
            _customerRepository.UnitOfWork.SaveChanges();

            CustomerPO customerPO2 = createCustomerPO();
            customerPO2.FirstName = "Ali";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO2, _customerService));
        }

        [Fact]
        public void ErrorIfPhoneNumberIsInvalid()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.PhoneNumber = "1234";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfEmailIsInvalid()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.PhoneNumber = "abcd";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void ErrorIfBankAccountIsInvalid()
        {
            CustomerPO customerPO = createCustomerPO();
            customerPO.PhoneNumber = "1234";
            Assert.Throws<InvalidCustomerValueException>(() => CustomerFactory.Create(customerPO, _customerService));
        }

        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            CustomerPO customerPO = createCustomerPO();
            var customer = CustomerFactory.Create(customerPO, _customerService);
            _customerRepository.Add(customer);
            _customerRepository.UnitOfWork.SaveChanges();

            Guid guidResult;
            Assert.True(Guid.TryParse(customer.Id.ToString(), out guidResult));
        }
        #endregion

        #region BDD
        // In StepDefinitions Folder
        #endregion

        #endregion

        // Please create more tests based on project requirements as per in readme.md
    }
}
