using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Infrastructure
{
    public abstract class Repository<TEntity,T> : IRepository<TEntity,T>
         where TEntity: Entity<T>
    {
        #region members
        private IUnitOfWork _unitOfWork;
        internal DbSet<TEntity> dbSet;
        #endregion

        #region constractor
        public Repository(IUnitOfWork unitOfWork)
        {
            //check preconditions
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            //set internal values
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.CreateSet<TEntity>();
        }
        #endregion

        #region public methods
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }
        public virtual void Add(TEntity entity)
        {
                dbSet.Add(entity); 
        }
        public async virtual Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }
        public async virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public virtual TEntity Get(T id)
        {
            return dbSet.Find(id);
        }
        public async virtual Task<TEntity> GetAsync(T id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

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
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }
        public virtual void Remove(T id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }
        #endregion
    }
}
