using CustomerFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinder.Services
{
    public class CustomerCsvExporter
    {
        public string ExportToCsv(List<Customer> customers)
        {
            StringBuilder builder = new StringBuilder();

            foreach (Customer customer in customers)
            {
                builder.AppendLine(
                    $"{customer.CustomerID},{customer.CompanyName},{customer.ContactName},{customer.Country}"
                );
            }

            return builder.ToString();
        }
    }
}
