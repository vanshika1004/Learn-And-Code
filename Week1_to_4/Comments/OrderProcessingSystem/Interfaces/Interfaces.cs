using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Interfaces
{
    public interface IPaymentGateway
    {
        Task<PaymentResult> ProcessPayment(string customerId, decimal amount, string paymentMethod);

        Task RefundPayment(string transactionId);
    }

    public interface IInventoryService
    {
        Task<bool> CheckAvailability(List<OrderItem> items);
        Task ReserveItems(List<OrderItem> items);
        Task CommitReservation(List<OrderItem> items);
        Task ReleaseReservation(List<OrderItem> items);
        Task RestoreInventory(List<OrderItem> items);
    }

    public interface INotificationService
    {
        Task SendOrderConfirmation(Order order);
    }
}
