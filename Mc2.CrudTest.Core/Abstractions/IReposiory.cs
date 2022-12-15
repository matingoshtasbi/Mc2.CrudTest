using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Abstractions
{
    public interface IRepository<TEntity,T>
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        TEntity Get(T id);
        Task<TEntity> GetAsync(T id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "");
        IEnumerable<TEntity> GetAll();
        void Remove(T id);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
