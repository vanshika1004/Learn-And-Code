using CustomerFinder.Models;
using CustomerFinder.SeedData;
using CustomerFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = CustomerSeedData.GetCustomers();

            CustomerSearchService searchService = new CustomerSearchService(customers);
            CustomerCsvExporter exporter = new CustomerCsvExporter();

            Console.WriteLine("Search Customers By:");
            Console.WriteLine("1. Country");
            Console.WriteLine("2. Company Name");
            Console.WriteLine("3. Contact Name");
            Console.Write("Enter your choice (1/2/3): ");

            string choice = Console.ReadLine();
            List<Customer> result = new List<Customer>();

            if (choice == "1")
            {
                Console.Write("Enter country: ");
                string country = Console.ReadLine();
                result = searchService.SearchByCountry(country);
            }
            else if (choice == "2")
            {
                Console.Write("Enter company name: ");
                string companyName = Console.ReadLine();
                result = searchService.SearchByCompanyName(companyName);
            }
            else if (choice == "3")
            {
                Console.Write("Enter contact name: ");
                string contactName = Console.ReadLine();
                result = searchService.SearchByContactName(contactName);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Console.WriteLine("\nSearch Results:");
            foreach (Customer customer in result)
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.ContactName} - {customer.Country}");
            }

            Console.WriteLine("\nCSV Output:");
            Console.WriteLine(exporter.ExportToCsv(result));

            Console.ReadLine();
        }
    }
}
