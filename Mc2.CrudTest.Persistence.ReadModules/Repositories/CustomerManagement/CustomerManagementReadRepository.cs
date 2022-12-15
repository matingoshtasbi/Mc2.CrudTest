using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Infrastructure.ReadModules.DbContexts;

namespace Mc2.CrudTest.Infrastructure.ReadModules.Repositories.CustomerManagement
{
    public class CustomerManagementReadRepository : ICustomerManagementReadRepository
    {
        #region members
        private QueryDbContext _dbContext;
        #endregion

        #region constractors
        public CustomerManagementReadRepository(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region public methods
        #endregion
    }
}
