using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet(initialBalance: 100m);
            Customer customer = new Customer("John", "Doe", wallet);
            Paperboy paperboy = new Paperboy();

            paperboy.CollectPayment(customer, paymentAmount: 30m);

            Console.WriteLine("Payment attempt completed.");
        }
    }
}
