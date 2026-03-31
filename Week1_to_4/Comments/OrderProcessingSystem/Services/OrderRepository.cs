using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Services
{
    public class OrderRepository
    {
        public async Task<Order> GetById(string orderId)
        {
            return await Task.FromResult(new Order());
        }

        public async Task Save(Order order)
        {
            await Task.CompletedTask;
        }
    }
}
