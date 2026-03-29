using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class OCP
    {
        public static void Run()
        {
            var items = new List<IInvoiceItem>
            {
                new RegularItem { Name = "Book", Price = 100m },
                new DiscountItem { Name = "Pen",  Price = 50m }
            };

            decimal total = 0;
            foreach (var item in items)
            {
                total += item.GetPrice();
                Console.WriteLine($"{item.Name} => {item.GetPrice()}");
            }

            Console.WriteLine($"Total: {total}");

        }
    }
    //OCP- Open Closed Principle - Open for Extension, Closed for Modification
    interface IInvoiceItem
    {
        string Name { get; set; }
        decimal Price { get; set; }
        decimal GetPrice();
    }

    class RegularItem : IInvoiceItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal GetPrice() => Price;
    }

    class DiscountItem : IInvoiceItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal GetPrice() => Price * 0.9m;
    }
}
