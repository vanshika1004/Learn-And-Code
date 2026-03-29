using CustomerFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinder.SeedData
{
    public static class CustomerSeedData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { CustomerID = 1, CompanyName = "ABC Corp", ContactName = "Ridhi", Country = "USA" },
                new Customer { CustomerID = 2, CompanyName = "XYZ Ltd", ContactName = "Raj", Country = "India" },
                new Customer { CustomerID = 3, CompanyName = "Global Tech", ContactName = "Ashu", Country = "Germany" },
                new Customer { CustomerID = 4, CompanyName = "SoftSolutions", ContactName = "Khushi", Country = "India" }
            };
        }
    }
}
