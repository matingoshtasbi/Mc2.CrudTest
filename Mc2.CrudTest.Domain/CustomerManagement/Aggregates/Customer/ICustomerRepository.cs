using Mc2.CrudTest.Application.Core.Abstractions;
using System;

namespace Mc2.CrudTest.Domain.CustomerManagement.Aggregates
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {

    }
}
