using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Customer).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.Address).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
