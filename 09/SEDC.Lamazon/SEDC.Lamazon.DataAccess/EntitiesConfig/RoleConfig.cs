using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitities;

namespace SEDC.Lamazon.DataAccess.EntitiesConfig
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}
