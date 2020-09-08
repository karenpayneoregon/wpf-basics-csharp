using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            ContactDevices = new HashSet<ContactDevices>();
            Customers = new HashSet<Customers>();
        }

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int ContactId { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Contact Type Id
        /// </summary>
        public int? ContactTypeIdentifier { get; set; }

        [ForeignKey(nameof(ContactTypeIdentifier))]
        [InverseProperty(nameof(ContactType.Contacts))]
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<ContactDevices> ContactDevices { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<Customers> Customers { get; set; }
    }
}