using CustomerFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinder.Services
{
    public class CustomerSearchService
    {
        private readonly List<Customer> customers;

        public CustomerSearchService(List<Customer> customerList)
        {
            customers = customerList;
        }

        public List<Customer> SearchByCountry(string country)
        {
            return Search(c => c.Country.Contains(country));
        }

        public List<Customer> SearchByCompanyName(string companyName)
        {
            return Search(c => c.CompanyName.Contains(companyName));
        }

        public List<Customer> SearchByContactName(string contactName)
        {
            return Search(c => c.ContactName.Contains(contactName));
        }

        private List<Customer> Search(System.Func<Customer, bool> condition)
        {
            return customers
                    .Where(condition)
                    .OrderBy(c => c.CustomerID)
                    .ToList();
        }
    }
}
