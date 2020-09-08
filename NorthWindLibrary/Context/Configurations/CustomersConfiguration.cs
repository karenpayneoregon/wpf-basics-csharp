using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            entity.HasKey(e => e.CustomerIdentifier)
                .HasName("PK_Customers_1");

            entity.Property(e => e.CustomerIdentifier).HasComment("Id");

            entity.Property(e => e.City).HasComment("City");

            entity.Property(e => e.CompanyName).HasComment("Company");

            entity.Property(e => e.ContactId).HasComment("ContactId");

            entity.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

            entity.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

            entity.Property(e => e.Fax).HasComment("Fax");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Modified Date");

            entity.Property(e => e.Phone).HasComment("Phone");

            entity.Property(e => e.PostalCode).HasComment("Postal Code");

            entity.Property(e => e.Region).HasComment("Region");

            entity.Property(e => e.Street).HasComment("Street");

            entity.HasOne(d => d.Contact)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Customers_Contacts");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Customers_ContactType");

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Customers_Countries");
        }
    }
}
