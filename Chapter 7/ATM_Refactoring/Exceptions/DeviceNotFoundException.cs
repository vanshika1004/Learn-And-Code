using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring.Exceptions
{
    public class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException()
            : base("ATM device not found.") { }
    }
}
