using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Services
{
    public class DummyPaymentGateway : IPaymentGateway
    {
        public Task<PaymentResult> ProcessPayment(
            string customerId,
            decimal amount,
            string paymentMethod)
        {
            return Task.FromResult(new PaymentResult
            {
                IsSuccessful = true,
                TransactionId = "TXN123"
            });
        }

        public Task RefundPayment(string transactionId)
        {
            return Task.CompletedTask;
        }
    }

    public class DummyInventoryService : IInventoryService
    {
        public Task<bool> CheckAvailability(List<OrderItem> items)
        {
            return Task.FromResult(true);
        }

        public Task ReserveItems(List<OrderItem> items)
        {
            return Task.CompletedTask;
        }

        public Task CommitReservation(List<OrderItem> items)
        {
            return Task.CompletedTask;
        }

        public Task ReleaseReservation(List<OrderItem> items)
        {
            return Task.CompletedTask;
        }

        public Task RestoreInventory(List<OrderItem> items)
        {
            return Task.CompletedTask;
        }
    }

    public class DummyNotificationService : INotificationService
    {
        public Task SendOrderConfirmation(Order order)
        {
            return Task.CompletedTask;
        }
    }
}
