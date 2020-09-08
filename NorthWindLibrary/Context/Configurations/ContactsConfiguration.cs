using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> entity)
        {
            entity.Property(e => e.ContactId).HasComment("Id");

            entity.Property(e => e.ContactTypeIdentifier).HasComment("Contact Type Id");

            entity.Property(e => e.FirstName).HasComment("First name");

            entity.Property(e => e.LastName).HasComment("Last name");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Contacts_ContactType");
        }
    }
}
