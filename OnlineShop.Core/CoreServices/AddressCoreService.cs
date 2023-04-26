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
    public class AddressCoreService : BaseService<Address>, IAddressCoreService
    {
        #region Ctor

        public AddressCoreService(IRepository<Address> addressRepositroy) : base(addressRepositroy)
        {

        }

        #endregion
    }
}
