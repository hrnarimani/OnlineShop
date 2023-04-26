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
    public class AddressService : IAddressService
    {
        #region Fields

        private readonly IAddressCoreService _addressCoreService;

        #endregion

        #region Ctor

        public AddressService(IAddressCoreService addressCoreService)
        {
            _addressCoreService = addressCoreService;
        }

        #endregion

        #region Methods

        public Task<AddressModel> Add(AddressModel Model)
        {
            throw new NotImplementedException();
        }

        public AddressModel Find  (int id)
        {
            return _addressCoreService.Find(id).ToModel<AddressModel>() ;
        }

        public Task<List<AddressModel>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AddressModel> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(AddressModel Model)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(AddressModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<AddressModel> Update(AddressModel Model)
        {
            throw new NotImplementedException();
        }

        public bool Validate(AddressModel Model, bool ThrowException = true)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
