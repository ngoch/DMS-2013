using DMS.Domain.Services;
using DMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public abstract class RepositoryBase<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DMSDbContext _DbContext;
        const string VersionPropertyName = "Version";

        public RepositoryBase(DMSDbContext dbContext)
        {
            Debug.Assert(dbContext != null);
            _DbContext = dbContext;
        }

        #region IRepository<T> Members

        public virtual IQueryable<T> GetAll(params string[] includes)
        {
            DbQuery<T> set = _DbContext.Set<T>();
            foreach (var item in includes)
            {
                set = set.Include(item);
            }

            return set;
        }

        public virtual T Get(int id)
        {
            return _DbContext.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                _DbContext.Set<T>().Add(entity);
            }
            catch (Exception)
            {
                var deleted = _DbContext.ChangeTracker.Entries().Where(d => d.State == System.Data.EntityState.Deleted);
                throw;
            }
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        //TODO: Review
        protected virtual T UpdateWhenLocal(T entity, Func<T, bool> keyPredicate, int keyValue)
        {
            var set = _DbContext.Set<T>();

            if (set.Local.Any(keyPredicate))
            {
                var oldEntity = set.Find(keyValue);

                if (oldEntity != null)
                {
                    var versionProperty = typeof(T).GetProperty(VersionPropertyName);

                    var oldEntityVersion = (byte[])versionProperty.GetValue(oldEntity, null);
                    var newEntityVersion = (byte[])versionProperty.GetValue(entity, null);

                    /*
                    if (!oldEntityVersion.Compare(newEntityVersion))
                    {
                        throw new DbUpdateConcurrencyException();
                    }*/
                    _DbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
                    entity = oldEntity;
                }
                else
                {
                    _DbContext.Entry(entity).State = EntityState.Modified;
                }
            }

            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _DbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual void SaveChanges()
        {
            _DbContext.SaveChanges();
        }

        #endregion

        protected virtual IQueryable<T> Page(IQueryable<T> data, CurrentPageInformation pagingInfo)
        {
            Debug.Assert(data != null);

            if (pagingInfo == null)
            {
                return data;
            }

            return data.Skip(pagingInfo.PageSize * (pagingInfo.Page - 1)).Take(pagingInfo.PageSize);
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
