using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindLibrary.Context;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Classes
{
    public class CustomerOperations
    {
        public static async Task<List<Customers>> SelectTopFiveCustomersAsync()
        {
            using (var context = new NorthwindContext())
            {
                return await Task.Run(() => context
                    .Customers.Take(5).ToList());

            }
        }
        public static async Task<bool> UpdateRange(List<Customers> items) 
        {

            using (var context = new NorthwindContext())
            {
                context.UpdateRange(items);
                return await context.SaveChangesAsync() == 5;
            }

        }

        /// <summary>
        /// Conventional loading of entities
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Customers.AsNoTracking()
                        .Include(customer => customer.Contact)
                        .ThenInclude(contact => contact.ContactDevices)
                        .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                        .Include(customer => customer.ContactTypeIdentifierNavigation)
                        .Include(customer => customer.CountryIdentifierNavigation)
                        .Select(customer => new CustomerItem()
                        {
                            CustomerIdentifier = customer.CustomerIdentifier,
                            CompanyName = customer.CompanyName,
                            ContactId = customer.Contact.ContactId,
                            Street = customer.Street,
                            City = customer.City,
                            PostalCode = customer.PostalCode,
                            CountryIdentifier = customer.CountryIdentifier,
                            Phone = customer.Phone,
                            ContactTypeIdentifier = customer.ContactTypeIdentifier,
                            Country = customer.CountryIdentifierNavigation.Name,
                            FirstName = customer.Contact.FirstName,
                            LastName = customer.Contact.LastName,
                            ContactTitle = customer.ContactTypeIdentifierNavigation.ContactTitle,
                            OfficePhoneNumber = customer.Contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
                        }).ToListAsync();


                }
            });
        }
    }
}
