using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Core.DTOs;
using Mc2.CrudTest.Infrastructure.ReadModules.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<CustomerVM> GetCustomer(Guid id)
        {
            var result = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id) ?? null!;

            return result;
        }

        public async Task<PageResult<CustomerVM>> GetCustomers(FindCustomerRequest request)
        {
            var result = new PageResult<CustomerVM>();
            result.PageIndex = request.PageIndex;
            result.PageSize = request.PageSize;

            var qry = _dbContext.Customers.AsNoTracking();
            //qry = qry.OrderBy(x => x.Id);
            //qry.filter

            result.TotalCount = await qry.CountAsync();

            qry = qry.Skip((request.PageIndex - 1) * request.PageSize);

            result.Results = await qry.Take(request.PageSize).ToListAsync();

            return result;
        }
        #endregion
    }
}
