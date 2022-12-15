using Mc2.CrudTest.Application.Core.Domain;
using Mc2.CrudTest.Domain.CustomerManagement.Exceptions;
using Mc2.CrudTest.Domain.CustomerManagement.Localization;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using PhoneNumbers;
using System;
using System.Text.RegularExpressions;

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
        string _bankAccountNumber = default!;
        #endregion

        #region constracors
        public Customer()
        {

        }

        public Customer(CustomerPO po, ICustomerService customerService)
        {
            CustomerService = customerService;
            validate(po);
            FirstName = po.FirstName;
            LastName = po.LastName;
            DateOfBirth = po.DateOfBirth;
            PhoneNumber = po.PhoneNumber;
            Email = po.Email;
            BankAccountNumber = po.BankAccountNumber;

        }
        #endregion

        #region properties

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string BankAccountNumber { get => _bankAccountNumber; set => _bankAccountNumber = value; }

        public ICustomerService CustomerService = default!;

        #endregion

        #region private methods
        private void validate(CustomerPO po)
        {
            if (string.IsNullOrEmpty(po.FirstName))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.FirstName });
            if (string.IsNullOrEmpty(po.LastName))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.LastName });
            if (po.DateOfBirth == new DateTime())
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.DateOfBirth });
            if (string.IsNullOrEmpty(po.Email))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.Email });
            if (string.IsNullOrEmpty(po.PhoneNumber))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.PhoneNumber });
            if (string.IsNullOrEmpty(po.BankAccountNumber))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.BankAccountNumber });
            if (CustomerService.IsUnique(Id , po.FirstName , po.LastName , po.DateOfBirth))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.RepeatedRecord, new string[] { CustomerManagementLocalization.CustomerInfo });
            if (CustomerService.IsUnique(Id, po.Email))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.RepeatedRecord, new string[] { CustomerManagementLocalization.Email });
            if (!IsValidPhoneNumber(po.PhoneNumber))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldInvalid, new string[] { CustomerManagementLocalization.PhoneNumber });
            if (!IsValidEmail(po.Email))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldInvalid, new string[] { CustomerManagementLocalization.Email });
            if (!Regex.IsMatch(po.BankAccountNumber, "((\\d{4})-){3}\\d{4}"))
                throw new InvalidCustomerValueException(CustomerManagementLocalization.FieldInvalid, new string[] { CustomerManagementLocalization.BankAccountNumber });
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            try
            {
                PhoneNumber result = PhoneNumberUtil.GetInstance().Parse(phoneNumber, "ir");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region public methods
        public void UpdateProperties(CustomerPO po)
        {
            validate(po);
            FirstName = po.FirstName;
            LastName = po.LastName;
            DateOfBirth = po.DateOfBirth;
            Email = po.Email;
            PhoneNumber = po.PhoneNumber;
            BankAccountNumber = po.BankAccountNumber;
        }
        #endregion
    }
}
