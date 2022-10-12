using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitities;
using System;

namespace SEDC.Lamazon.DataAccess.EntitiesConfig
{
    public class ProductCategoryStatusConfig : IEntityTypeConfiguration<ProductCategoryStatus>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}
