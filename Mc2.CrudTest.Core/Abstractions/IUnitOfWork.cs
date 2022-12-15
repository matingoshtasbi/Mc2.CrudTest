using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
        int ExecuteCommand(string sqlCommand, params object[] parameters);
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
        int SaveChanges();
        DbContext DbContext { get; }
        Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters);
        Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string sqlQuery, params object[] parameters);
        Task<int> SaveChangesAsync();
    }
}
