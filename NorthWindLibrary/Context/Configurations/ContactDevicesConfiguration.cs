using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class ContactDevicesConfiguration : IEntityTypeConfiguration<ContactDevices>
    {
        public void Configure(EntityTypeBuilder<ContactDevices> entity)
        {
            entity.HasOne(d => d.Contact)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_ContactDevices_Contacts1");

            entity.HasOne(d => d.PhoneTypeIdentifierNavigation)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.PhoneTypeIdentifier)
                .HasConstraintName("FK_ContactDevices_PhoneType");
        }
    }
}
