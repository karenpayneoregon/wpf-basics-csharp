using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
            Suppliers = new HashSet<Suppliers>();
        }

        [Key]
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Employees> Employees { get; set; }
        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}