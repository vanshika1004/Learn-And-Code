using OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Services
{
    public class OrderValidator
    {
        public bool IsValid(Order order)
        {
            return order != null
                && order.Items?.Count > 0
                && order.TotalAmount > 0;
        }
    }
}
