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
    }
}
