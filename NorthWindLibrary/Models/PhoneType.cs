using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            ContactDevices = new HashSet<ContactDevices>();
        }

        [Key]
        public int PhoneTypeIdenitfier { get; set; }
        public string PhoneTypeDescription { get; set; }

        [InverseProperty("PhoneTypeIdentifierNavigation")]
        public virtual ICollection<ContactDevices> ContactDevices { get; set; }
    }
}