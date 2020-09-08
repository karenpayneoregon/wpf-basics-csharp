using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> entity)
        {
            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Suppliers_Countries");
        }
    }
}
