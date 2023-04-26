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
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IProductCoreService _productCoreService;

        #endregion

        #region Ctor

        public ProductService(IProductCoreService productCoreService)
        {
            _productCoreService = productCoreService;
        }

        #endregion

        #region Methods

        public  async  Task<ProductModel> Add(ProductModel Model)
        {
            var product = Model.ToEntity<Product>();
            _productCoreService.Add(product);
            return product.ToModel<ProductModel>();
        }


        public ProductModel Find(int Id)
        {
            return _productCoreService.Find(Id).ToModel<ProductModel>();
        }

        public async Task<List<ProductModel>> FindAllAsync()
        {
            return _productCoreService.GetAll().ToList().ToListModel<ProductModel, Product>();
        }

        public Task<ProductModel> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ProductModel Model)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(ProductModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Update(ProductModel Model)
        {
            throw new NotImplementedException();
        }

        public bool Validate(ProductModel Model, bool ThrowException = true)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
