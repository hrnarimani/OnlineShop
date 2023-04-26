using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Interfaces
{
    public interface IOnlineShopDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void Save();
        Task<int> SaveAsync();
    }
}
