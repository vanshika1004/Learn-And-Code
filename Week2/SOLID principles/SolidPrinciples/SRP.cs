using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class SRP
    {
        public static void Run()
        {
            var order = new Order { Id = 1, Amount = 500m };

            var calculator = new OrderPriceCalculator();
            var printer = new OrderPrinter();

            var total = calculator.CalculateTotal(order);
            printer.Print(order, total);

        }
    }
    // SRP - Single Responsibility Principle - This principle says a class should have only one reason to change.
    class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
    class OrderPriceCalculator
    {
        public decimal CalculateTotal(Order order)
        {
            decimal discount = order.Amount > 300 ? 50m : 0m;
            return order.Amount - discount;
        }
    }

    class OrderPrinter
    {
        public void Print(Order order, decimal total)
        {
            Console.WriteLine($"Order #{order.Id}");
            Console.WriteLine($"Original Amount: {order.Amount}");
            Console.WriteLine($"Total After Discount: {total}");
        }
    }
}
