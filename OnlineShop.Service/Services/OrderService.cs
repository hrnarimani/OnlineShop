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
    public class OrderService : IOrderService
    {
        #region Fields

        private readonly IOrderCoreService _orderCoreService;

        #endregion

        #region Ctor

        public OrderService(IOrderCoreService orderCoreService)
        {
            _orderCoreService = orderCoreService;
        }

        #endregion

        #region Methods

        public Task<OrderModel> Add(OrderModel Model)
        {
            throw new NotImplementedException();
        }

        public OrderModel Find(int Id)
        {
            return _orderCoreService.Find(Id).ToModel<OrderModel>();
        }

        public Task<List<OrderModel>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(OrderModel Model)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(OrderModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> Update(OrderModel Model)
        {
            throw new NotImplementedException();
        }

        public bool Validate(OrderModel Model, bool ThrowException = true)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
