using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.CoreServices
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IRepository<TEntity> _repository;

        #endregion

        #region Ctor

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public virtual void Add(TEntity entity)
        {
            _repository.AddEntity(entity);
        }
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _repository.AddMany(entities);
        }
        public virtual TEntity AddEntity(TEntity entity)
        {
            return _repository.AddEntity(entity);
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            _repository.UpdateMany(entities);
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public virtual async Task<List<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.UpdateManyAsync(entities);
        }
        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            _repository.Delete(where);
        }
        public virtual void DeleteMany(IEnumerable<TEntity> entities)
        {
            _repository.DeleteMany(entities);
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }
        public virtual TEntity Find(object key)
        {
            return _repository.Find(key);
        }
        public virtual async Task<TEntity> FindAsync(object key)
        {
            return await _repository.FindAsync(key);
        }
        public virtual IQueryable<TEntity> GetAllQuery()
        {
            return _repository.GetAllQuery();
        }
        public virtual IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetAllQuery(where, includes);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetAll(where, includes);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await _repository.GetAllAsync(includes);
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Get(where, includes);
        }

        #endregion


    }
}
