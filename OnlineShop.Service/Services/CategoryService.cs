using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces.IServices;
using OnlineShop.Service.IServices;
using OnlineShop.Service.Mapping;
using OnlineShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly ICategoryCoreService _categoryCoreService;

        #endregion

        #region Ctor

        public CategoryService(ICategoryCoreService categoryCoreService)
        {
            _categoryCoreService = categoryCoreService;
        }

        #endregion

        #region Methods

        public async Task<CategoryModel> Add(CategoryModel Model)
        {
            var category = Model.ToEntity<Category>();
            _categoryCoreService.Add(category);
            return category.ToModel<CategoryModel>();
        }

        public CategoryModel Find(int Id)
        {
            return _categoryCoreService.Find(Id).ToModel<CategoryModel>();
        }

        public async Task<List<CategoryModel>> FindAllAsync()
        {
            return _categoryCoreService.GetAll().ToList().ToListModel<CategoryModel, Category>();
        }

        public Task<CategoryModel> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CategoryModel Model)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CategoryModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> Update(CategoryModel Model)
        {
            throw new NotImplementedException();
        }

        public bool Validate(CategoryModel Model, bool ThrowException = true)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
