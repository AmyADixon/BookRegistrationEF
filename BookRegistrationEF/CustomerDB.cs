using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF {
    static class CustomerDB {
        public static List<Customer> GetAllCustomers() {
            BookContext context = new BookContext();

            return context.Customer.ToList();
        }

        /// <summary>
        /// Adds a new customer to the DB
        /// </summary>
        /// <param name="person">The customer the user wants to add </param>
        public static void Add(Customer person) { // CustomerDB.Add()
            var context = new BookContext();

            context.Customer.Add(person);

            context.SaveChanges();
        }
    }
}
