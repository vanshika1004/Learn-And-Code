using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeter
{
    public class Paperboy
    {
        public void CollectPayment(Customer customer, decimal paymentAmount)
        {
            bool isAmountPaid = customer.Pay(paymentAmount);

            if (!isAmountPaid)
            {
                // To Do: Fix this later
            }
        }
    }
}
