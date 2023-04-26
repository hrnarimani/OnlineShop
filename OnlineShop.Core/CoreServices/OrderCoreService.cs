using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.CoreServices
{
    public class OrderCoreService : BaseService<Order>, IOrderCoreService
    {
        #region Ctor

        public OrderCoreService(IRepository<Order> orderRepositroy) : base(orderRepositroy)
        {

        }

        #endregion
    }
}
