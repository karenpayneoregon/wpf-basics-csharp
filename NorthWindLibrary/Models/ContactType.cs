using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contacts>();
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }

        [InverseProperty("ContactTypeIdentifierNavigation")]
        public virtual ICollection<Contacts> Contacts { get; set; }
        [InverseProperty("ContactTypeIdentifierNavigation")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("ContactTypeIdentifierNavigation")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}