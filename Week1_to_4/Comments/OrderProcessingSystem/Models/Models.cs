using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        Cancelled
    }

    public class OrderResult
    {
        public bool IsSuccessful { get; }
        public string Message { get; }
        public string TransactionId { get; }

        private OrderResult(bool success, string message, string transactionId)
        {
            IsSuccessful = success;
            Message = message;
            TransactionId = transactionId;
        }

        public static OrderResult Success(string transactionId) =>
            new OrderResult(true, "Success", transactionId);

        public static OrderResult Failed(string message) =>
            new OrderResult(false, message, null);

        public static OrderResult Invalid(string message) =>
            new OrderResult(false, message, null);
    }

    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
