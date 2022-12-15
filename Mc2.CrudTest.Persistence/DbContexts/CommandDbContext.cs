using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.DbContexts
{
    public class CommandDbContext : DbContext
    {
        #region constractor
        public CommandDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region properties
        public DbSet<Customer> Customers { get; set; } = default!;

        #endregion 

        #region protected methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommandDbContext).Assembly);
        }
        #endregion
    }
}
