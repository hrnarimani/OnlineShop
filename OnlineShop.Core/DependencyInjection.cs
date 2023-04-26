using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Core.CoreServices;
using OnlineShop.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddressCoreService, AddressCoreService>();
            services.AddScoped<ICategoryCoreService, CategoryCoreService>();
            services.AddScoped<ICustomerCoreService, CustomerCoreService>();
            services.AddScoped<IOrderCoreService, OrderCoreService>();
            services.AddScoped<IProductCoreService, ProductCoreService>();
            return services;
        }
    }
}
