using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Props

        IQueryable<TEntity> Table { get; }

        #endregion

        #region Methods

        void AddMany(IEnumerable<TEntity> entities);
        TEntity AddEntity(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void DeleteMany(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        TEntity Find(object key);
        Task<TEntity> FindAsync(object key);
        IQueryable<TEntity> GetAllQuery();
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        TEntity Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);


        #endregion


    }
}
