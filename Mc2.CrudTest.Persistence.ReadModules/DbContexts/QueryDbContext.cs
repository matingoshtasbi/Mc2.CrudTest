using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.ReadModules.DbContexts
{
    public class QueryDbContext : DbContext
    {
        #region constractors
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }
        #endregion

        #region properties
        public DbSet<CustomerVM> Customers { get; set; } = default!;

        #endregion

        #region protected methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QueryDbContext).Assembly);
        }
        #endregion
    }
}
