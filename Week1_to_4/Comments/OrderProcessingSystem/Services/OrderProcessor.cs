using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Services
{
    public class OrderProcessor
    {
        private readonly OrderValidator _validator;
        private readonly OrderServices _services;
        private readonly OrderRepository _repository;

        public OrderProcessor(OrderValidator validator, OrderServices services, OrderRepository repository)
        {
            _validator = validator;
            _services = services;
            _repository = repository;
        }

        public async Task<OrderResult> ProcessOrder(Order order)
        {
            if (!_validator.IsValid(order))
            {
                return OrderResult.Invalid("Order validation failed");
            }

            return await _services.PlaceOrder(order);
        }

        public async Task CancelOrder(string orderId)
        {
            var order = await _repository.GetById(orderId);
            await _services.CancelOrder(order);
            await _repository.Save(order);
        }
    }
}
