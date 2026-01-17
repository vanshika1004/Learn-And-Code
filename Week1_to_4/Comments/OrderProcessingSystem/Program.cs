using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;
using System;
using System.Collections.Generic;

namespace OrderProcessingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentGateway paymentGateway = new DummyPaymentGateway();
            IInventoryService inventoryService = new DummyInventoryService();
            INotificationService notificationService = new DummyNotificationService();

            var validator = new OrderValidator();
            var repository = new OrderRepository();

            var services = new OrderServices(paymentGateway, inventoryService, notificationService);

            var processor = new OrderProcessor(validator, services, repository);

            var order = new Order
            {
                CustomerId = "CUST-1",
                TotalAmount = 500,
                PaymentMethod = "Card",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = "P1", Quantity = 1 }
                }
            };

            var result = processor.ProcessOrder(order).GetAwaiter().GetResult();

            Console.WriteLine(result.Message);
            Console.ReadKey();
        }
    }
}
