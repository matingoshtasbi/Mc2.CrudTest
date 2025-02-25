﻿using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.SqlServer.DbContexts
{
    public class SqlServerCommandDbContext : CommandDbContext
    {
        #region constractor
        public SqlServerCommandDbContext(DbContextOptions<SqlServerCommandDbContext> options) : base(options)
        {
        }
        #endregion
    }
}

