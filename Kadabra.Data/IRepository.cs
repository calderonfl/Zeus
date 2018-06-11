using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kadabra.Data
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        Task<int> Count<TEntity>() where TEntity : class;
        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> Delete<TEntity>(TEntity entity) where TEntity : class;
        Task<IEnumerable<TEntity>> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<IEnumerable<TEntity>> Get<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;
        Task<IEnumerable<TEntity>> Get<TEntity, TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;
        Task<IQueryable<TEntity>> GetQuery<TEntity>() where TEntity : class;
        Task<IQueryable<TEntity>> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity> Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task Save();
    }
}