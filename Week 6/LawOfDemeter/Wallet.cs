using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeter
{
    public class Wallet
    {
        private decimal _balance;

        public Wallet(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public bool DebitAmount(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }

            return false;
        }
    }

}
