using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring.Exceptions
{
    public class NetworkConnectionException : Exception
    {
        public NetworkConnectionException()
            : base("ATM is not connected to network.") { }
    }
}
