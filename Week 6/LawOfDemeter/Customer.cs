using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeter
{
    public class Customer
    {
        private readonly Wallet _wallet;

        public string FirstName { get; }
        public string LastName { get; }

        public Customer(string firstName, string lastName, Wallet wallet)
        {
            FirstName = firstName;
            LastName = lastName;
            _wallet = wallet;
        }

        public bool Pay(decimal amount)
        {
            return _wallet.DebitAmount(amount);
        }
    }

}
