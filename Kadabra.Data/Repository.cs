using Kadabra.Data.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kadabra.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private readonly PluralizationService pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(this.context);
                }
                return unitOfWork;
            }
        }
        public Repository()
        {
            context = new KadabraContext();
        }
        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }

        private TEntity GetByKey(object keyValue)
        {
            EntityKey key = GetEntityKey(keyValue);
            object originalItem;
            if (((IObjectContextAdapter)context).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }
        private EntityKey GetEntityKey(object keyValue)
        {
            var entitySetName = GetEntityName();
            var objectSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }
        private string GetEntityName()
        {
            return string.Format("{0}.{1}", ((IObjectContextAdapter)context).ObjectContext.DefaultContainerName, pluralizer.Pluralize(typeof(TEntity).Name));
        }

        public virtual async Task<IQueryable<TEntity>> GetQuery()
        {
            return await Task<IQueryable<TEntity>>.Run(() => 
            {
                var entityName = GetEntityName();
                return ((IObjectContextAdapter)context).ObjectContext.CreateQuery<TEntity>(entityName);
            });
        }

        public virtual async Task<IQueryable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return (await GetQuery()).Where(predicate);
        }

        public virtual async Task<TEntity> Single(Expression<Func<TEntity, bool>> criteria)
        {
            return (await GetQuery()).Single<TEntity>(criteria);
        }

        public virtual async Task<TEntity> First(Expression<Func<TEntity, bool>> predicate)
        {
            return (await GetQuery()).First(predicate);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Add(entity));
        }

        public virtual async Task<TEntity> Attach(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Attach(entity));
        }

        public virtual async Task<TEntity> Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Remove(entity));
        }

        public virtual async Task Delete(Expression<Func<TEntity, bool>> criteria)
        {
            IEnumerable<TEntity> records = await Find(criteria);
            foreach (TEntity record in records)
            {
                await Delete(record);
            }
            await context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            var fqen = GetEntityName();
            object originalItem;
            EntityKey key = ((IObjectContextAdapter)context).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)context).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                await Task.Run(() => ((IObjectContextAdapter)context).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity));
            }
            return default(TEntity);
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return (await GetQuery()).Where(criteria);
        }

        public virtual async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> criteria)
        {
            return (await GetQuery()).Where(criteria).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return (await GetQuery()).AsEnumerable();
        }

        public virtual async Task<IEnumerable<TEntity>> Get<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return (await GetQuery()).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return (await GetQuery()).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public virtual async Task<IEnumerable<TEntity>> Get<TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return (await GetQuery(criteria)).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return (await GetQuery(criteria)).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public virtual async Task<int> Count()
        {
            return (await GetQuery()).Count();
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> criteria)
        {
            return (await GetQuery(criteria)).Count();
        }

        public virtual async Task Save()
        { 
            await context.SaveChangesAsync();
        }
    }
}
