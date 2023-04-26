using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.IServices
{
    public interface IService<TModel>
    {
        public Task<List<TModel>> FindAllAsync();

        public Task<TModel> Add(TModel Model);

        public Task<TModel> Update(TModel Model);

        public Task SaveAsync(TModel Model);

        public Task<TModel> FindAsync(int Id);

        public bool Validate(TModel Model, bool ThrowException = true);

        public Task RemoveAsync(TModel Model);
        public TModel Find(int Id);
    }
}
