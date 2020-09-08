using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Models;
using System;

namespace NorthWindLibrary.Context
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> entity)
        {
            entity.HasOne(d => d.CustomerIdentifierNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerIdentifier)
                .HasConstraintName("FK_Orders_Customers2");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
