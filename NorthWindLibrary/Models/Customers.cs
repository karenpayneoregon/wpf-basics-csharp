using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindLibrary.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int CustomerIdentifier { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        public int? ContactId { get; set; }
        /// <summary>
        /// Street
        /// </summary>
        [StringLength(60)]
        public string Street { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [StringLength(15)]
        public string City { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        [StringLength(15)]
        public string Region { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        [StringLength(10)]
        public string PostalCode { get; set; }
        /// <summary>
        /// CountryIdentifier
        /// </summary>
        public int? CountryIdentifier { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        [StringLength(24)]
        public string Phone { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        [StringLength(24)]
        public string Fax { get; set; }
        /// <summary>
        /// ContactTypeIdentifier
        /// </summary>
        public int? ContactTypeIdentifier { get; set; }
        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty(nameof(Contacts.Customers))]
        public virtual Contacts Contact { get; set; }
        [ForeignKey(nameof(ContactTypeIdentifier))]
        [InverseProperty(nameof(ContactType.Customers))]
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        [ForeignKey(nameof(CountryIdentifier))]
        [InverseProperty(nameof(Countries.Customers))]
        public virtual Countries CountryIdentifierNavigation { get; set; }
        [InverseProperty("CustomerIdentifierNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}