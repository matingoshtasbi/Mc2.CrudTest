using System;

namespace Mc2.CrudTest.Domain.CustomerManagement.Services
{
    public interface ICustomerService
    {
        bool IsUnique(Guid id, string firstName, string lastName, DateTime dateOfBirth);
        bool IsUnique(Guid id, string email);
    }
}
