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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        }
    }
}
