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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Picture).IsRequired(false);
        }
    }
}
