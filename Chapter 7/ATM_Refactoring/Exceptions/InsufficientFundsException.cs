using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
            : base("Insufficient funds in account.") { }
    }
}
