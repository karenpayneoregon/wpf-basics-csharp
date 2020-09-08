using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> entity)
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        }
    }
}
