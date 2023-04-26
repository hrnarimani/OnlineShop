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
    public class CustomerService : ICustomerService
    {
        #region Fields

        private readonly ICustomerCoreService _customerCoreService;

        #endregion

        #region Ctor

        public CustomerService(ICustomerCoreService customerCoreService)
        {
            _customerCoreService = customerCoreService;
        }

        #endregion

        #region Methods

        public Task<CustomerModel> Add(CustomerModel Model)
        {
            throw new NotImplementedException();
        }

        public CustomerModel Find(int Id)
        {
            return _customerCoreService.Find(Id).ToModel<CustomerModel>();
        }

        public Task<List<CustomerModel>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CustomerModel Model)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CustomerModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> Update(CustomerModel Model)
        {
            throw new NotImplementedException();
        }

        public bool Validate(CustomerModel Model, bool ThrowException = true)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
