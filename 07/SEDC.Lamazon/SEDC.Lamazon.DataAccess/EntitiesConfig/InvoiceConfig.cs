﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitities;

namespace SEDC.Lamazon.DataAccess.EntitiesConfig
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(10, 2);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Invoice_User");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Invoice_Order");

            builder.HasOne(x => x.InvoiceStatus)
               .WithMany(x => x.Invoices)
               .HasForeignKey(x => x.InvoiceStatusId)
               .OnDelete(DeleteBehavior.NoAction)
               .HasConstraintName("FK_Invoice_InvoiceStatus");
        }
    }
}
