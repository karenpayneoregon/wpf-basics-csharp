using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class ContactDevices
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public int? PhoneTypeIdentifier { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty(nameof(Contacts.ContactDevices))]
        public virtual Contacts Contact { get; set; }
        [ForeignKey(nameof(PhoneTypeIdentifier))]
        [InverseProperty(nameof(PhoneType.ContactDevices))]
        public virtual PhoneType PhoneTypeIdentifierNavigation { get; set; }
    }
}