using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Infrastructure;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using System;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories.CustomerManagement
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractors
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
