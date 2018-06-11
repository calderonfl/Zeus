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
    public class Repository : IRepository
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

        private TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
        {
            EntityKey key = GetEntityKey<TEntity>(keyValue);
            object originalItem;
            if (((IObjectContextAdapter)context).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }
        private EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
        {
            var entitySetName = GetEntityName<TEntity>();
            var objectSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }
        private string GetEntityName<TEntity>() where TEntity : class
        {
            return string.Format("{0}.{1}", ((IObjectContextAdapter)context).ObjectContext.DefaultContainerName, pluralizer.Pluralize(typeof(TEntity).Name));
        }

        public async Task<IQueryable<TEntity>> GetQuery<TEntity>() where TEntity : class
        {
            return await Task<IQueryable<TEntity>>.Run(() => 
            {
                var entityName = GetEntityName<TEntity>();
                return ((IObjectContextAdapter)context).ObjectContext.CreateQuery<TEntity>(entityName);
            });
        }

        public async Task<IQueryable<TEntity>> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return (await GetQuery<TEntity>()).Where(predicate);
        }

        public async Task<TEntity> Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return (await GetQuery<TEntity>()).Single<TEntity>(criteria);
        }

        public async Task<TEntity> First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return (await GetQuery<TEntity>()).First(predicate);
        }

        public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Add(entity));
        }

        public async Task<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Attach(entity));
        }

        public async Task<TEntity> Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return await Task.Run(() => context.Set<TEntity>().Remove(entity));
        }

        public async Task Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IEnumerable<TEntity> records = await Find<TEntity>(criteria);
            foreach (TEntity record in records)
            {
                await Delete<TEntity>(record);
            }
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            var fqen = GetEntityName<TEntity>();
            object originalItem;
            EntityKey key = ((IObjectContextAdapter)context).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)context).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                await Task.Run(() => ((IObjectContextAdapter)context).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity));
            }
            return default(TEntity);
        }

        public async Task<IEnumerable<TEntity>> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return (await GetQuery<TEntity>()).Where(criteria);
        }

        public async Task<TEntity> FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return (await GetQuery<TEntity>()).Where(criteria).FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return (await GetQuery<TEntity>()).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity, TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return (await GetQuery<TEntity>()).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return (await GetQuery<TEntity>()).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return (await GetQuery<TEntity>(criteria)).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return (await GetQuery<TEntity>(criteria)).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public async Task<int> Count<TEntity>() where TEntity : class
        {
            return (await GetQuery<TEntity>()).Count();
        }

        public async Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return (await GetQuery<TEntity>(criteria)).Count();
        }

        public async Task Save()
        { 
            await context.SaveChangesAsync();
        }
    }
}
