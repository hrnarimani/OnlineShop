using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Repository;


namespace OnlineShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOnlineShopDbContext>(provider => provider.GetService<OnlineShopDbContext>());
            services.AddScoped<IRepository<Customer>, EfRepository<Customer>>();
            services.AddScoped<IRepository<Order>, EfRepository<Order>>();
            services.AddScoped<IRepository<Address>, EfRepository<Address>>();
            services.AddScoped<IRepository<Category>, EfRepository<Category>>();
            services.AddScoped<IRepository<Product>, EfRepository<Product>>();
            services.AddScoped<UserManager<IdentityUser>, UserManager<IdentityUser>>();
            services.AddScoped<SignInManager<IdentityUser>, SignInManager<IdentityUser>>();

            return services;
        }
    }
}
