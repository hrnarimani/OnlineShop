using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using OnlineShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly OnlineShopDbContext _context;
        private DbSet<TEntity> _entities;

        #endregion

        #region Props

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }
        public virtual IQueryable<TEntity> Table => Entities;

        #endregion

        #region Ctor

        public EfRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();
                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }
            _context.Save();
            return exception.ToString();
        }
        protected IQueryable<TEntity> DbsetInclude(List<Expression<Func<TEntity, object>>> includes)
        {
            IQueryable<TEntity> query = Entities.AsQueryable();
            if (includes != null)
                includes.ForEach(f => query = query.Include(f));
            return query;
        }

        #endregion

        #region Methods


        public virtual void AddMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.AddRange(entities);
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual TEntity AddEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Add(entity);
                _context.Save();
                return entity;
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Add(entity);
                await _context.SaveAsync();
                return entity;
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                //Entities.Remove(entity);
                _context.Remove(entity);
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                List<TEntity> query = Entities.Where(where).ToList();
                query.ForEach(f => Entities.Remove(f));
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void DeleteMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.RemoveRange(entities);
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Remove(entity);
                await _context.SaveAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Update(entity);
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.UpdateRange(entities);
                _context.Save();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual async Task<List<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.UpdateRange(entities);
                await _context.SaveAsync();
                return entities.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TEntity Find(object key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            try
            {
                return Entities.Find(key);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<TEntity> FindAsync(object key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            try
            {
                return await Entities.FindAsync(key);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IQueryable<TEntity> GetAllQuery()
        {
            try
            {
                return Entities.AsQueryable();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return DbsetInclude(includes.ToList()).Where(where);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Entities.ToList();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return DbsetInclude(includes.ToList()).ToList();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return DbsetInclude(includes.ToList()).Where(where).ToList();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Entities.ToListAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return await DbsetInclude(includes.ToList()).ToListAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return DbsetInclude(includes.ToList()).Where(where).FirstOrDefault();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return await DbsetInclude(includes.ToList()).Where(where).FirstOrDefaultAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return DbsetInclude(includes.ToList()).Where(where).ToList();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                return await DbsetInclude(includes.ToList()).Where(where).ToListAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        #endregion
    }
}
