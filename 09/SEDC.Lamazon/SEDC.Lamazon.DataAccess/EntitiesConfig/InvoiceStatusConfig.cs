using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitities;

namespace SEDC.Lamazon.DataAccess.EntitiesConfig
{
    public class InvoiceStatusConfig : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}
