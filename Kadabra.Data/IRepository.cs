using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kadabra.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Attach(TEntity entity);
        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> criteria);
        Task Delete(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> First(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> Get<TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);
        Task<IEnumerable<TEntity>> Get<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> GetQuery();
        Task<IQueryable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Single(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> Update(TEntity entity);
        Task Save();
    }
}