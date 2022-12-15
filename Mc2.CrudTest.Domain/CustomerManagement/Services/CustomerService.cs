using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using System;
using System.Linq;

namespace Mc2.CrudTest.Domain.CustomerManagement.Services
{
    public class CustomerService : ICustomerService
    {
        #region members
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region constractors
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region public methods
        public bool IsUnique(Guid exceptId, string firstName, string lastName, DateTime dateOfBirth)
        {
            return _customerRepository.Get(c =>
            c.Id != exceptId &&
            c.FirstName == firstName &&
            c.LastName == lastName &&
            c.DateOfBirth == dateOfBirth).Any();
        }

        public bool IsUnique(Guid exceptId, string email)
        {
            return _customerRepository.Get(c =>
            c.Id != exceptId &&
            c.Email == email).Any();
        }
        #endregion
    }
}
