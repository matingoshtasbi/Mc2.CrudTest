using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.Sqlite.DbContexts
{
    public class SqliteCommandDbContext : CommandDbContext
    {
        #region constractor
        public SqliteCommandDbContext(DbContextOptions<SqliteCommandDbContext> options) : base(options)
        {
        }
        #endregion
    }
}
