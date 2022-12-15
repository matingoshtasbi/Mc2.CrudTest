using Mc2.CrudTest.Application.Core.Domain;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using System;

namespace Mc2.CrudTest.Domain.CustomerManagement.Aggregates
{
    public class Customer : Entity<Guid>
    {
        #region members
        string _firstName = default!;
        string _lastName = default!;
        DateTime _dateOfBirth = default!;
        string _phoneNumber = default!;
        string _email = default!;
        ulong _bankAccountNumber = default!;
        #endregion

        #region constracors
        public Customer()
        {

        }

        public Customer(CustomerPO po, ICustomerService customerService)
        {

        }
        #endregion

        #region properties

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Email { get => _email; set => _email = value; }

        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public ulong BankAccountNumber { get => _bankAccountNumber; set => _bankAccountNumber = value; }

        public ICustomerService CustomerService = default!;

        #endregion

        #region private methods
        #endregion

        #region public methods
        #endregion
    }
}
