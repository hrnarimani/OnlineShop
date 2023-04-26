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
    public class CustomerCoreService : BaseService<Customer>, ICustomerCoreService
    {
        #region Ctor

        public CustomerCoreService(IRepository<Customer> customerRepositroy) : base(customerRepositroy)
        {

        }

        #endregion
    }
}
