using OnlineShop.Core.Entities;
using OnlineShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Mapping
{
    public static class MappingExtentions
    {
        #region Utilities

        private static TDestination Map<TDestination>(this object source)
        {
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #endregion

        #region Model-Entity Mapping

        public static TModel ToModel<TModel>(this BaseEntity entity) where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return entity.Map<TModel>();
        }

        public static List<TModel> ToListModel<TModel, TEntity>(this List<TEntity> entities)
        {
            List<TModel> personViews = AutoMapperConfiguration.Mapper.Map<List<TEntity>, List<TModel>>(entities);
            return personViews;
        }

        public static TModel ToModel<TEntity, TModel>(this TEntity entity, TModel model) where TEntity : BaseEntity where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return entity.MapTo(model);
        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/

        public static TEntity ToEntity<TEntity>(this BaseModel model) where TEntity : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return model.Map<TEntity>();
        }

        public static List<TEntity> ToListEntity<TEntity, TModel>(this List<TModel> models)
        {
            List<TEntity> personViews = AutoMapperConfiguration.Mapper.Map<List<TModel>, List<TEntity>>(models);
            return personViews;
        }

        public static TEntity ToEntity<TEntity, TModel>(this TModel model, TEntity entity) where TEntity : BaseEntity where TModel : BaseModel
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return model.MapTo(entity);
        }

        #endregion
    }
}
