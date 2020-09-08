using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> entity)
        {
            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Employees_ContactType");

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Employees_Countries");
        }
    }
}
