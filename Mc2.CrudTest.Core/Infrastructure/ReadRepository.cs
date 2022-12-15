using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Infrastructure
{
    public class ReadRepository<TEntity, T> : IReadRepository<TEntity, T>
        where TEntity : Entity<T> where T : IComparable<T>

    {
        #region members
        DbContext _dbContext;
        internal DbSet<TEntity> dbSet;
        #endregion

        #region constractor
        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<TEntity>();
        }
        #endregion

        #region public methods
        public async Task<TEntity> Get(T id, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking().AsQueryable();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query; ;
            }
        }
        //public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "",int pageIndex , int pageSize)
        //{
        //    IQueryable<TEntity> query = dbSet.AsNoTracking().AsQueryable();

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).Skip(1).Take(1);
        //    }
        //    else
        //    {
        //        return query.Skip(1).Take(1) ;
        //    }
        //}
        #endregion
    }
}
