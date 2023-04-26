using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using OnlineShop.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data
{
    public class OnlineShopDbContext : IdentityDbContext, IOnlineShopDbContext
    {
        #region Props

        #endregion

        #region Ctor

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
          : base(options)
        {
        }

        #endregion

        #region Methods

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void Save()
        {
            SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            Task<int> result = new Task<int>(() => 0);

            return await result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        #endregion

        #region Static Methods

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Customer"))
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string adminUserEmail = "admin@shop.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new IdentityUser()
                    {
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Abc.12345678");
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }

        #endregion

    }
}
