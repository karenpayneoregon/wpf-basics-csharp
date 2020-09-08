using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Classes
{
    public class Customer
    {
        [NotMapped] public string FirstName { get; set; }
        [NotMapped] public string LastName { get; set; }
        /// <summary>
        /// Project for CustomerItem from Customers
        /// </summary>
        public static Expression<Func<Customers, CustomerItem>> Projection =>
            (customer) => new CustomerItem()
            {
                CustomerIdentifier = customer.CustomerIdentifier,
                CompanyName = customer.CompanyName,
                ContactId = customer.ContactId,
                ContactTitle = customer.ContactTypeIdentifierNavigation.ContactTitle,
                FirstName = customer.Contact.FirstName,
                LastName = customer.Contact.LastName,
                CountryIdentifier = customer.CountryIdentifier,
                Country = customer.CountryIdentifierNavigation.Name,
                ContactTypeIdentifier = customer.CountryIdentifier,
                OfficePhoneNumber = customer.Contact.ContactDevices
                    .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
            };
    }
}
