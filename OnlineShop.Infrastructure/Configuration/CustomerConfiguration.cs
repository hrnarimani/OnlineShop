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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FullName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Username).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(50).IsRequired();
        }
    }
}
