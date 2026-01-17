using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Services
{
    public class OrderServices
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly IInventoryService _inventoryService;
        private readonly INotificationService _notificationService;

        public OrderServices(
            IPaymentGateway paymentGateway,
            IInventoryService inventoryService,
            INotificationService notificationService)
        {
            _paymentGateway = paymentGateway;
            _inventoryService = inventoryService;
            _notificationService = notificationService;
        }

        public async Task<OrderResult> PlaceOrder(Order order)
        {
            if (!await _inventoryService.CheckAvailability(order.Items))
            {
                return OrderResult.Failed("Insufficient inventory");
            }

            await _inventoryService.ReserveItems(order.Items);

            try
            {
                var payment =
                    await _paymentGateway.ProcessPayment(
                        order.CustomerId,
                        order.TotalAmount,
                        order.PaymentMethod);

                if (!payment.IsSuccessful)
                {
                    await _inventoryService.ReleaseReservation(order.Items);
                    return OrderResult.Failed(payment.ErrorMessage);
                }

                await _inventoryService.CommitReservation(order.Items);
                await _notificationService.SendOrderConfirmation(order);

                return OrderResult.Success(payment.TransactionId);
            }
            catch
            {
                await _inventoryService.ReleaseReservation(order.Items);
                throw;
            }
        }

        public async Task CancelOrder(Order order)
        {
            if (order.Status == OrderStatus.Paid)
            {
                await _paymentGateway.RefundPayment(order.TransactionId);
                await _inventoryService.RestoreInventory(order.Items);
            }

            order.Status = OrderStatus.Cancelled;
        }
    }
}
