using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Persistence.UnitofWork
{
    public class MainUnitOfWork :IUnitOfWork
    {
        #region members
        private CommandDbContext _context=default!;
        #endregion

        #region constractors
        public MainUnitOfWork(CommandDbContext context) 
        {
            _context = context;
        }
        #endregion

        #region properties
        public DbContext DbContext { get => _context; }
        #endregion

        #region public methods
        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>();
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
        public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
        #endregion
    }
}